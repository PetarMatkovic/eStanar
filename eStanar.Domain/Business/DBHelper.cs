using eStanar.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace eStanar.Domain.Business
{
    public static class DBHelper
    {
        public static List<NoticeDetails> GetNoticeDetails(int idPerson, int? idStructure)
        {
            List<NoticeDetails> noticeDetails = null;

            using (eStanarContext context = new eStanarContext())
            {
                SqlParameter idPersonParameter = new SqlParameter()
                {
                    ParameterName = "@idPersonIn",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = idPerson
                };

                SqlParameter idStructureParameter = new SqlParameter()
                {
                    ParameterName = "@idStructureIn",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = (object)idStructure ?? DBNull.Value
                };

                noticeDetails = context.Database.SqlQuery<NoticeDetails>("GetNotices @idPersonIn, @idStructureIn", idPersonParameter, idStructureParameter).ToList();
            }

            return noticeDetails;
        }

        public static void GetNoticeById(int idNotice, ref NoticeDetails nDet, ref List<NoticeComment> comments)
        {
            nDet = new NoticeDetails();

            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "GetNoticeById";

                        SqlParameter idNoticeParameter = new SqlParameter()
                        {
                            ParameterName = "@idNoticeIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idNotice
                        };

                        oaCommand.Parameters.Add(idNoticeParameter);

                        var objectContext = ((IObjectContextAdapter)context).ObjectContext;

                        using (IDataReader dataReader = oaCommand.ExecuteReader())
                        {
                            nDet = objectContext.Translate<NoticeDetails>(dataReader as DbDataReader).ToList().First();

                            dataReader.NextResult();

                            comments = objectContext.Translate<NoticeComment>(dataReader as DbDataReader).ToList();
                        }
                    }
                }
            }
        }

        public static void InsertNoticeComment(int idNotice, string text, int idAuthor)
        {
            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "InsertNoticeCommet";

                        SqlParameter idNoticeParameter = new SqlParameter()
                        {
                            ParameterName = "@idNoticeIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idNotice
                        };

                        SqlParameter textParameter = new SqlParameter()
                        {
                            ParameterName = "@textIn",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = text
                        };

                        SqlParameter idAuthorParameter = new SqlParameter()
                        {
                            ParameterName = "@idAuthorIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idAuthor
                        };

                        oaCommand.Parameters.Add(idNoticeParameter);
                        oaCommand.Parameters.Add(textParameter);
                        oaCommand.Parameters.Add(idAuthorParameter);

                        oaCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}

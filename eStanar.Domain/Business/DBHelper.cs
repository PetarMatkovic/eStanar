using eStanar.Domain.Concrete;
using eStanar.Domain.Entities;
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

        public static List<NoticeType> GetNoticeTypesAll()
        {
            List<NoticeType> noticeTypes = null;

            using (eStanarContext context = new eStanarContext())
            {

                noticeTypes = context.Database.SqlQuery<NoticeType>("GetNoticeTypesAll").ToList();
            }

            return noticeTypes;
        }

        public static void InsertNotice(int idNoticeType, int idStructure, string text, int idAuthor, int? idEntrance, int? idMeeting)
        {
            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "InsertNotice";
                        
                        SqlParameter idNoticeTypeParameter = new SqlParameter()
                        {
                            ParameterName = "@idNoticeTypeIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idNoticeType
                        };

                        SqlParameter idStructureParameter = new SqlParameter()
                        {
                            ParameterName = "@idStructureIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idStructure
                        };

                        SqlParameter textInParameter = new SqlParameter()
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

                        SqlParameter idEntranceParameter = new SqlParameter()
                        {
                            ParameterName = "@idEntranceIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idEntrance.HasValue ? idEntrance : (object)DBNull.Value
                        };

                        SqlParameter idMeetingParameter = new SqlParameter()
                        {
                            ParameterName = "@idMeetingIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idMeeting.HasValue ? idMeeting : (object)DBNull.Value
                        };

                        oaCommand.Parameters.Add(idNoticeTypeParameter);
                        oaCommand.Parameters.Add(idStructureParameter);
                        oaCommand.Parameters.Add(textInParameter);
                        oaCommand.Parameters.Add(idAuthorParameter);
                        oaCommand.Parameters.Add(idEntranceParameter);
                        oaCommand.Parameters.Add(idMeetingParameter);

                        oaCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        public static int? InsertPoll(int? idNotice, string text, DateTime dateFrom, DateTime? dateTo)
        {
            int? idPoll = null;
            int tmpInt = 0;

            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "InsertPoll";

                        SqlParameter idNoticeParameter = new SqlParameter()
                        {
                            ParameterName = "@idNoticeIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)idNotice ?? DBNull.Value
                        };

                        SqlParameter textInParameter = new SqlParameter()
                        {
                            ParameterName = "@textIn",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)text ?? DBNull.Value
                        };

                        SqlParameter dateFromParameter = new SqlParameter()
                        {
                            ParameterName = "@dateFromIn",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dateFrom
                        };

                        SqlParameter dateToParameter = new SqlParameter()
                        {
                            ParameterName = "@dateToIn",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)dateTo ?? DBNull.Value
                        };

                        SqlParameter idPollParameter = new SqlParameter()
                        {
                            ParameterName = "@idPollOut",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Output
                        };

                        oaCommand.Parameters.Add(idNoticeParameter);
                        oaCommand.Parameters.Add(textInParameter);
                        oaCommand.Parameters.Add(dateFromParameter);
                        oaCommand.Parameters.Add(dateToParameter);
                        oaCommand.Parameters.Add(idPollParameter);

                        oaCommand.ExecuteNonQuery();

                        if (Int32.TryParse(idPollParameter.Value.ToString(), out tmpInt))
                            idPoll = tmpInt;
                    }
                }
            }

            return idPoll;
        }

        public static int? UpdatePoll(int idPoll, int? idNotice, string text, DateTime dateFrom, DateTime? dateTo)
        {
            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "UpdatePoll";

                        SqlParameter idPollParameter = new SqlParameter()
                        {
                            ParameterName = "@idPollIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)idPoll ?? DBNull.Value
                        };

                        SqlParameter idNoticeParameter = new SqlParameter()
                        {
                            ParameterName = "@idNoticeIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)idNotice ?? DBNull.Value
                        };

                        SqlParameter textInParameter = new SqlParameter()
                        {
                            ParameterName = "@textIn",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)text ?? DBNull.Value
                        };

                        SqlParameter dateFromParameter = new SqlParameter()
                        {
                            ParameterName = "@dateFromIn",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dateFrom
                        };

                        SqlParameter dateToParameter = new SqlParameter()
                        {
                            ParameterName = "@dateToIn",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)dateTo ?? DBNull.Value
                        };

                        oaCommand.Parameters.Add(idPollParameter);
                        oaCommand.Parameters.Add(idNoticeParameter);
                        oaCommand.Parameters.Add(textInParameter);
                        oaCommand.Parameters.Add(dateFromParameter);
                        oaCommand.Parameters.Add(dateToParameter);

                        oaCommand.ExecuteNonQuery();
                    }
                }
            }

            return idPoll;
        }

        public static void GetPoll(int idPoll, out PollDetails pollDetails, out List<PollOption> pollOptionList)
        {
            pollDetails = null;
            pollOptionList = null;

            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "GetPollById";

                        SqlParameter idNoticeParameter = new SqlParameter()
                        {
                            ParameterName = "@idPollIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idPoll
                        };

                        oaCommand.Parameters.Add(idNoticeParameter);

                        var objectContext = ((IObjectContextAdapter)context).ObjectContext;

                        using (IDataReader dataReader = oaCommand.ExecuteReader())
                        {
                            pollDetails = objectContext.Translate<PollDetails>(dataReader as DbDataReader).ToList().First();

                            dataReader.NextResult();

                            pollOptionList = objectContext.Translate<PollOption>(dataReader as DbDataReader).ToList();
                        }
                    }
                }
            }
        }

        public static int? InsertPollOption(int idPoll, string text)
        {
            int? idPollOption = null;
            int tmpInt = 0;

            using (eStanarContext context = new eStanarContext())
            {
                using (IDbConnection oaConnection = context.Database.Connection)
                {
                    oaConnection.Open();

                    using (IDbCommand oaCommand = oaConnection.CreateCommand())
                    {
                        oaCommand.CommandType = CommandType.StoredProcedure;
                        oaCommand.CommandText = "InsertPollOption";

                        SqlParameter idPollParameter = new SqlParameter()
                        {
                            ParameterName = "@idPollIn",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = idPoll
                        };

                        SqlParameter textInParameter = new SqlParameter()
                        {
                            ParameterName = "@textIn",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (object)text ?? DBNull.Value
                        };

                        SqlParameter idPollOptionParameter = new SqlParameter()
                        {
                            ParameterName = "@idPollOptionOut",
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Output
                        };

                        oaCommand.Parameters.Add(idPollParameter);
                        oaCommand.Parameters.Add(textInParameter);
                        oaCommand.Parameters.Add(idPollOptionParameter);

                        oaCommand.ExecuteNonQuery();

                        if (Int32.TryParse(idPollOptionParameter.Value.ToString(), out tmpInt))
                            idPollOption = tmpInt;
                    }
                }
            }

            return idPollOption;
        }
    }
}

using eStanar.Domain.Concrete;
using eStanar.Domain.Entities;
using System;
using System.Collections.Generic;
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
    }
}

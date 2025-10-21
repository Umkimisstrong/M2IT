using RutinusApi.Data;
using RutinusApi.Models;

namespace RutinusApi.Repositories
{
    /// <summary>
    /// CodeRepository : 코드 작업저장소
    /// </summary>
    public class CodeRepository
    {
        /* DbContext */
        private readonly RutinusDbContext _context;
        private readonly string _connectionString;

        /// <summary>
        /// CodeRepository : 생성자
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <param name="config">Configuration</param>
        public CodeRepository(RutinusDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// GetCodeValueItems : DB 에서 특정 코드를 Cd와 Value 형태로 가져온다.
        /// </summary>
        /// <param name="sysCd">시스템코드</param>
        /// <param name="divCd">분류코드</param>
        /// <returns></returns>
        public List<CodeDto> GetCodeValueItems(string sysCd, string divCd)
        {
            var query = from innerItem in _context.Codes
                        where innerItem.SysCd == sysCd && innerItem.DivCd == divCd
                        orderby innerItem.SortOrder
                        select new CodeDto
                        {
                            Cd = innerItem.Cd,
                            CdNm = innerItem.CdNm,
                            
                        };

            return query.ToList<CodeDto>();
        }

        /// <summary>
        /// GetCodeValueRuleItems : 부위코드로 훈련 종목을 Cd 와 Value 형태로 가져온다.
        /// </summary>
        /// <param name="bodyPartCd">부위코드</param>
        /// <returns></returns>
        public List<CodeDto> GetCodeValueRuleItems(string bodyPartCd)
        {
            var query = from outerItem in _context.Rules
                        join innerItemCodes1 in _context.Codes
                        on outerItem.RtnCd equals innerItemCodes1.Cd
                        join innerItemCodes2 in _context.Codes
                        on outerItem.BodyPartCd equals innerItemCodes2.Cd
                        where outerItem.BodyPartCd == bodyPartCd
                           && innerItemCodes1.SysCd == "RTN_CD"
                           && innerItemCodes2.SysCd == "CMM"
                           && innerItemCodes2.DivCd == "BODY_PART"
                        select new CodeDto
                        {
                            Cd = outerItem.RtnCd,
                            CdNm = innerItemCodes1.CdNm,
                        };

            return query.ToList<CodeDto>();
        }
    }
}

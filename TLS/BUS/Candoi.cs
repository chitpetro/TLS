using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
namespace BUS
{
    public class Candoi
    {

        // năm nay
        public static double c100 = 0;
        //110
        public static double c110 = 0;
        public static double c111 = 0;
        public static double c112 = 0;
        //120
        public static double c120 = 0;
        public static double c121 = 0;
        public static double c122 = 0;
        public static double c123 = 0;
        //130
        public static double c130 = 0;
        public static double c131 = 0;
        public static double c132 = 0;
        public static double c133 = 0;
        public static double c134 = 0;
        public static double c135 = 0;
        public static double c136 = 0;
        public static double c137 = 0;
        public static double c139 = 0;

        // 140 
        public static double c140 = 0;
        public static double c141 = 0;
        public static double c149 = 0;
        // 150
        public static double c150 = 0;
        public static double c151 = 0;
        public static double c152 = 0;
        public static double c153 = 0;
        public static double c154 = 0;
        public static double c155 = 0;
        //200
        public static double c200 = 0;
        //210
        public static double c210 = 0;
        public static double c211 = 0;
        public static double c212 = 0;
        public static double c213 = 0;
        public static double c214 = 0;
        public static double c215 = 0;
        public static double c216 = 0;
        public static double c219 = 0;
        //220
        public static double c220 = 0;
        public static double c221 = 0;
        public static double c222 = 0;
        public static double c223 = 0;
        public static double c224 = 0;
        public static double c225 = 0;
        public static double c226 = 0;
        public static double c227 = 0;
        public static double c228 = 0;
        public static double c229 = 0;
        //230
        public static double c230 = 0;
        public static double c231 = 0;
        public static double c232 = 0;
        //240
        public static double c240 = 0;
        public static double c241 = 0;
        public static double c242 = 0;
        //250
        public static double c250 = 0;
        public static double c251 = 0;
        public static double c252 = 0;
        public static double c253 = 0;
        public static double c254 = 0;
        public static double c255 = 0;
        //260
        public static double c260 = 0;
        public static double c261 = 0;
        public static double c262 = 0;
        public static double c263 = 0;
        public static double c268 = 0;
        //270
        public static double c270 = 0;
        //300
        public static double c300 = 0;

        //310
        public static double c310 = 0;
        public static double c311 = 0;
        public static double c312 = 0;
        public static double c313 = 0;
        public static double c314 = 0;
        public static double c315 = 0;
        public static double c316 = 0;
        public static double c317 = 0;
        public static double c318 = 0;
        public static double c319 = 0;
        public static double c320 = 0;
        public static double c321 = 0;
        public static double c322 = 0;
        public static double c323 = 0;
        public static double c324 = 0;
        //330
        public static double c330 = 0;
        public static double c331 = 0;
        public static double c332 = 0;
        public static double c333 = 0;
        public static double c334 = 0;
        public static double c335 = 0;
        public static double c336 = 0;
        public static double c337 = 0;
        public static double c338 = 0;
        public static double c339 = 0;
        public static double c340 = 0;
        public static double c341 = 0;
        public static double c342 = 0;
        public static double c343 = 0;
        //400
        public static double c400 = 0;
        //410
        public static double c410 = 0;
        public static double c411 = 0;
        public static double c411a = 0;
        public static double c411b = 0;
        public static double c412 = 0;
        public static double c413 = 0;
        public static double c414 = 0;
        public static double c415 = 0;
        public static double c416 = 0;
        public static double c417 = 0;
        public static double c418 = 0;
        public static double c419 = 0;
        public static double c420 = 0;
        public static double c421 = 0;
        public static double c421a = 0;
        public static double c421b = 0;
        public static double c422 = 0;
        //430
        public static double c430 = 0;
        public static double c431 = 0;
        public static double c432 = 0;
        //440
        public static double c440 = 0;




        // Năm trước

        public static double d100 = 0;
        //110
        public static double d110 = 0;
        public static double d111 = 0;
        public static double d112 = 0;
        //120
        public static double d120 = 0;
        public static double d121 = 0;
        public static double d122 = 0;
        public static double d123 = 0;
        //130
        public static double d130 = 0;
        public static double d131 = 0;
        public static double d132 = 0;
        public static double d133 = 0;
        public static double d134 = 0;
        public static double d135 = 0;
        public static double d136 = 0;
        public static double d137 = 0;
        public static double d139 = 0;

        // 140 
        public static double d140 = 0;
        public static double d141 = 0;
        public static double d149 = 0;
        // 150
        public static double d150 = 0;
        public static double d151 = 0;
        public static double d152 = 0;
        public static double d153 = 0;
        public static double d154 = 0;
        public static double d155 = 0;
        //200
        public static double d200 = 0;
        //210
        public static double d210 = 0;
        public static double d211 = 0;
        public static double d212 = 0;
        public static double d213 = 0;
        public static double d214 = 0;
        public static double d215 = 0;
        public static double d216 = 0;
        public static double d219 = 0;
        //220
        public static double d220 = 0;
        public static double d221 = 0;
        public static double d222 = 0;
        public static double d223 = 0;
        public static double d224 = 0;
        public static double d225 = 0;
        public static double d226 = 0;
        public static double d227 = 0;
        public static double d228 = 0;
        public static double d229 = 0;
        //230
        public static double d230 = 0;
        public static double d231 = 0;
        public static double d232 = 0;
        //240
        public static double d240 = 0;
        public static double d241 = 0;
        public static double d242 = 0;
        //250
        public static double d250 = 0;
        public static double d251 = 0;
        public static double d252 = 0;
        public static double d253 = 0;
        public static double d254 = 0;
        public static double d255 = 0;
        //260
        public static double d260 = 0;
        public static double d261 = 0;
        public static double d262 = 0;
        public static double d263 = 0;
        public static double d268 = 0;
        //270
        public static double d270 = 0;
        //300
        public static double d300 = 0;

        //310
        public static double d310 = 0;
        public static double d311 = 0;
        public static double d312 = 0;
        public static double d313 = 0;
        public static double d314 = 0;
        public static double d315 = 0;
        public static double d316 = 0;
        public static double d317 = 0;
        public static double d318 = 0;
        public static double d319 = 0;
        public static double d320 = 0;
        public static double d321 = 0;
        public static double d322 = 0;
        public static double d323 = 0;
        public static double d324 = 0;
        //330
        public static double d330 = 0;
        public static double d331 = 0;
        public static double d332 = 0;
        public static double d333 = 0;
        public static double d334 = 0;
        public static double d335 = 0;
        public static double d336 = 0;
        public static double d337 = 0;
        public static double d338 = 0;
        public static double d339 = 0;
        public static double d340 = 0;
        public static double d341 = 0;
        public static double d342 = 0;
        public static double d343 = 0;
        //400
        public static double d400 = 0;
        //410
        public static double d410 = 0;
        public static double d411 = 0;
        public static double d411a = 0;
        public static double d411b = 0;
        public static double d412 = 0;
        public static double d413 = 0;
        public static double d414 = 0;
        public static double d415 = 0;
        public static double d416 = 0;
        public static double d417 = 0;
        public static double d418 = 0;
        public static double d419 = 0;
        public static double d420 = 0;
        public static double d421 = 0;
        public static double d421a = 0;
        public static double d421b = 0;
        public static double d422 = 0;
        //430
        public static double d430 = 0;
        public static double d431 = 0;
        public static double d432 = 0;
        //440
        public static double d440 = 0;


        // Báo cáo kết quả hoạt động kinh doanh

        public static double d01 = 0;
        public static double d02 = 0;
        public static double d10 = 0;
        public static double d11 = 0;
        public static double d20 = 0;
        public static double d21 = 0;
        public static double d22 = 0;
        public static double d23 = 0;
        public static double d25 = 0;
        public static double d26 = 0;
        public static double d30 = 0;
        public static double d31 = 0;
        public static double d32 = 0;
        public static double d40 = 0;
        public static double d50 = 0;
        public static double d51 = 0;
        public static double d52 = 0;
        public static double d60 = 0;
        public static double d70 = 0;
        public static double d71 = 0;


        public static double c01 = 0;
        public static double c02 = 0;
        public static double c10 = 0;
        public static double c11 = 0;
        public static double c20 = 0;
        public static double c21 = 0;
        public static double c22 = 0;
        public static double c23 = 0;
        public static double c25 = 0;
        public static double c26 = 0;
        public static double c30 = 0;
        public static double c31 = 0;
        public static double c32 = 0;
        public static double c40 = 0;
        public static double c50 = 0;
        public static double c51 = 0;
        public static double c52 = 0;
        public static double c60 = 0;
        public static double c70 = 0;
        public static double c71 = 0;

        // báo cáo lưu chuyển tiền tệ

        // năm nay
        public static double tn01 = 0;
        public static double tn02 = 0;
        public static double tn03 = 0;
        public static double tn04 = 0;
        public static double tn05 = 0;
        public static double tn06 = 0;
        public static double tn07 = 0;
        public static double tn20 = 0;
        public static double tn21 = 0;
        public static double tn22 = 0;
        public static double tn23 = 0;
        public static double tn24 = 0;
        public static double tn25 = 0;
        public static double tn26 = 0;
        public static double tn27 = 0;
        public static double tn30 = 0;
        public static double tn31 = 0;
        public static double tn32 = 0;
        public static double tn33 = 0;
        public static double tn34 = 0;
        public static double tn35 = 0;
        public static double tn36 = 0;
        public static double tn40 = 0;
        public static double tn50 = 0;
        public static double tn60 = 0;
        public static double tn61 = 0;
        public static double tn70 = 0;

        // năm trước
        public static double tt01 = 0;
        public static double tt02 = 0;
        public static double tt03 = 0;
        public static double tt04 = 0;
        public static double tt05 = 0;
        public static double tt06 = 0;
        public static double tt07 = 0;
        public static double tt20 = 0;
        public static double tt21 = 0;
        public static double tt22 = 0;
        public static double tt23 = 0;
        public static double tt24 = 0;
        public static double tt25 = 0;
        public static double tt26 = 0;
        public static double tt27 = 0;
        public static double tt30 = 0;
        public static double tt31 = 0;
        public static double tt32 = 0;
        public static double tt33 = 0;
        public static double tt34 = 0;
        public static double tt35 = 0;
        public static double tt36 = 0;
        public static double tt40 = 0;
        public static double tt50 = 0;
        public static double tt60 = 0;
        public static double tt61 = 0;
        public static double tt70 = 0;



    }
}

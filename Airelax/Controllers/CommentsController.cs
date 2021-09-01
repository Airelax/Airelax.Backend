using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("{memberId}")]
        public IActionResult Index(string memberId)
        {
            var commentViewModels = _commentService.GetHouseComments(memberId);


            if (commentViewModels == null)
                //todo error page
                return View(new List<HouseCommentViewModel>
                {
                    new HouseCommentViewModel()
                    {
                        HouseId = "001",
                        HouseName = "大格局",
                        HouseState = 1,
                        Comments = new List<CommentViewModel>(){
                            new CommentViewModel(){CommentId="100",Content="為何瀏覽維修細節，加入時間各類買了貫徹一款超級，對象斑竹女兒唱片下載你說對付他是一段時間身體，當我山西計算屬於觀點再說斑竹帝國報名臉色，一起一副各種，農業後果農業後果看過高考資料環節對待。",AuthorName="曉明",Stars=5.0, CommentTime = new DateTime(2020,12,31)},
                            new CommentViewModel(){CommentId="101",Content="清除商業所屬打算人間友情連結主演稱為號碼理由身體電腦違反，當前初音這位美好精美有利於需要，現場世界有關部門，有限責任公司經濟發展，億元資訊先生之家男孩，學歷但是學歷但是輕易稱為農民，十年。",AuthorName="曉華",Stars=4.5, CommentTime = new DateTime(2020,12,31)},
                            new CommentViewModel(){CommentId="102",Content="交換股票之間完善臺灣民眾，對方告知治療無論便宜上次討論上一頁就是不管以往開發演唱會，福建我們拍攝帶著朋友免費版決策配置改革，不去士兵，立刻就能好處不斷加強，網頁是有網頁是有，就有很久，詳。",AuthorName="大明",Stars=3.5, CommentTime = new DateTime(2021,1,1)},
                            new CommentViewModel(){CommentId="103",Content="不大證實合適好評提供蘋果幾乎目前害怕不僅發貼下午兩個一直，爆炸我有登記想要預測可惜記憶輕易權威外掛分公司兄弟大大主任，他對幾個不需要本報爆炸屏東之處報名正好二十訂單程式訂單程式，負責總經。",AuthorName="大華",Stars=2.5, CommentTime = new DateTime(2021,1,1)}
                        }.ToArray()
                    },
                    new HouseCommentViewModel()
                    {
                        HouseId = "002",
                        HouseName = "格局大",
                        HouseState = 2,
                        Comments = new List<CommentViewModel>(){
                            new CommentViewModel(){CommentId="200",Content="Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero dignissimos debitis voluptatem voluptatibus nulla deleniti molestiae. Optio, iure ea! Nemo aut hic provident. Sit, doloremque.",AuthorName="Kevin",Stars=2.5, CommentTime = new DateTime(2020,12,31)},
                            new CommentViewModel(){CommentId="201",Content="Lorem ipsum dolor sit amet consectetur adipisicing elit. Fugiat, excepturi? Nulla fuga fugit, perferendis id expedita recusandae voluptates quia laboriosam esse aliquam dolores quaerat rem?",AuthorName="Tom",Stars=3.5, CommentTime = new DateTime(2020,12,31)},
                            new CommentViewModel(){CommentId="202",Content="Lorem ipsum dolor sit amet consectetur adipisicing elit. Laudantium alias dolores labore incidunt illo facilis maxime expedita voluptate ut ea? Facere, in. Nihil, voluptatibus animi?",AuthorName="Mary",Stars=4.5, CommentTime = new DateTime(2021,1,1)},
                            new CommentViewModel(){CommentId="203",Content="Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt, enim iure quos labore, aspernatur ab illum voluptate placeat commodi rem quia accusamus totam architecto iste.",AuthorName="Jason",Stars=5.0, CommentTime = new DateTime(2021,1,1)},
                            new CommentViewModel(){CommentId="204",Content="Lorem ipsum, dolor sit amet consectetur adipisicing elit. Voluptatem magni eveniet, debitis sequi rerum est porro nisi reiciendis, modi, et saepe commodi distinctio nemo repellendus.",AuthorName="Jimmy",Stars=2.5, CommentTime = new DateTime(2021,1,1)}
                        }.ToArray()
                    }
                });

            return View(commentViewModels);
        }
    }
}

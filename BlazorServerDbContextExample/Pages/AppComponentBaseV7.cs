
using BlazorServerDbContextExample.Data;
using CaotunSpring002.Adapter;
using CaotunSpring002.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace CaotunSpring002
{

    //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase?view=aspnetcore-5.0
    // NOTE by Mark, 2021-02-03
    // 共有的, 先做在這裡
    public class AppComponentBaseV7 : ComponentBase
    {
        [Inject] // 和 Startup.ConfigureServices 呼應
        public IDbContextFactory<ContactContext> DbFactory { get; set; }
     
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        public NavigationManager Nav { get; set; }



        [Inject]
        public IPageHelperV7 PageHelper { get; set; }

        [Inject]
        public IWebHostEnvironment _webHostEnvironment { get; set; }

        //private readonly IWebHostEnvironment _webHostEnvironment;

        //public HomeController(
        //    IWebHostEnvironment webHostEnvironment)
        //{
        //    _webHostEnvironment = webHostEnvironment;
        //}


        [Parameter]

        public int Page // Page Number
        {
            get
            {
                return PageHelper.Page;
            }
            set
            {
                PageHelper.Page = value;
            }
        }


      //  string rootPath = _webHostEnvironment.WebRootPath


        // 本地 Item List, 存放本頁面要顯示的內容, 
        // 經過實驗, 使用 Object List
        // 如果使用 Entity Type, 像List<Sales>, 就不能封裝到這個 Base
        public List<Object> Items { get; set; }

        public async Task<List<Object>> GetItemsAsync(string ENT, IAdapterV7 a)
        {
            var db = DbFactory.CreateDbContext();
            List<Object> objs = new();
            switch (ENT)
            {
                case nameof(Contact):
                    PageHelper.TotalItemCount = db.Contacts.Where(a.GetWhere()).Count();
                    objs = await db.Contacts.Where(a.GetWhere()).OrderBy(a.GetOrderBy())
                            .Skip(PageHelper.Skip).Take(PageHelper.PageSize).ToListAsync<Object>();
                    break;

                //case nameof(Part):
                //    PageHelper.TotalItemCount = db.Part.Where(a.GetWhere()).Count();
                //    objs = await db.Part.Where(a.GetWhere()).OrderBy(a.GetOrderBy())
                //            .Skip(PageHelper.Skip).Take(PageHelper.PageSize).ToListAsync<Object>();
                //    break;
            }
            // List<Object> objs = new();
            PageHelper.PageItems = objs.Count;
            return objs;
        }

        public string PageRouteBase { get; set; }

        // 2. 如何給 PRE??? TODO
        protected override void OnAfterRender(bool firstRender) // 原範例,已調整導航
        {
            //  var x = PageRouteBase;

            var x = PageHelper.BaseUrl;
            if (_lastPage < 1)
            {
                Nav.NavigateTo(x + "1");
                return;
            }

            if (PageHelper.PageCount > 0)
            {
                if (Page < 1)
                {
                    Nav.NavigateTo(x + "1");
                    return;
                }
                if (Page >= PageHelper.PageCount)
                {
                    // NOTE by Mark, 2021-02-04
                    // 故意將頁面走到超出的 199
                    // 是會進到這裡兩次
                    // 有點浪費, 但功能正常,
                    // 反應速度可以的
                    Nav.NavigateTo(x + "" + PageHelper.PageCount);
                    return;
                }
            }

            base.OnAfterRender(firstRender);
        }




        //     protected WrapperV3 Wrapper { get; set; } // 整個頁面的剛性骨架
        protected WrapperV7 Wrapper { get; set; } // 整個頁面的剛性骨架

        //      protected override void OnAfterRender(bool firstRender) { }

        protected int _lastPage = -1;// 原範例,不動

        //NOTE by Mark, 2021-02-04
        //The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it 
        //to be overridden in a derived class
        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual


        protected virtual Task ReloadAsync()
        {
            return Task.CompletedTask;
        }




        // 7. working!
        protected override async Task OnInitializedAsync()
        {
            await ReloadAsync();
        }


        // 3. 調用 ReloadAsync,是否能仍移動 Base, override ReloadAsync
        //           Page  _lastPage
        // stage 1:    0      -1
        // stage 2:    1       0
        protected async override Task OnParametersSetAsync() // 原範例,不動
        {
            // Make sure the page really chagned.
            if (Page != _lastPage)
            {
                _lastPage = Page;
                await ReloadAsync();
            }
            await base.OnParametersSetAsync();
        }


        protected string TABLE_CONFIG;
        protected string PRE;
        protected string TITLE;
        protected override void OnInitialized()
        {
            int PRE_CHAR_CNT = 3;
            //var guess=this.GetType().Name.Substring(0, 4);
            //PRE = this.GetType().Name.Substring(0, 4);
            PRE = this.GetType().Name.Substring(0, PRE_CHAR_CNT);

            PageHelper.PageSize = 5; //DOING
            PageHelper.BaseUrl = "/" + PRE + "/";
          //  TITLE = "" + this.GetType().Name.Substring(4).ToUpper();
            TITLE = "" + this.GetType().Name.Substring(PRE_CHAR_CNT).ToUpper();

            //   TITLE = "銷售";


            //   string rootPath = _webHostEnvironment.WebRootPath;
            //   string[] paths = { @"d:\archives", "2001", "media", "images" };
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.path.altdirectoryseparatorchar?view=net-5.0
            TABLE_CONFIG = Path.Combine(_webHostEnvironment.WebRootPath, "TABLE_CONFIG/");

            //https://stackoverflow.com/questions/9065598/if-a-folder-does-not-exist-create-it
            Directory.CreateDirectory(TABLE_CONFIG);

            //if (Configuration["TABLE_CONFIG"]!=null || Configuration["TABLE_CONFIG"]!= "")
            //{
            //    TABLE_CONFIG = Configuration["TABLE_CONFIG"];
            //}
           


        }
    }
}

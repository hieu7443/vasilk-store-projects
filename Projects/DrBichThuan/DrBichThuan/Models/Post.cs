using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Common;
using Vasilk.Store.Foundations.Models;

namespace DrBichThuan.Models
{
    public class PostListModel
    {
        public Post[] Data { get; set; }
        public QuerySettings QuerySettings { get; set; }
        public int Page { get; set; }
        public int MaxPage { get { int max = Convert.ToInt32(QuerySettings.Total / AppConstants.PostPerPage); return AppConstants.PostPerPage * max == QuerySettings.Total ? max - 1 : max; } }
        public int StartPage { get { return Page <= 0 ? 0 : Page >= MaxPage ? MaxPage : Page; } }
    }
    public class Post
    {
        public BaseProperty Base { get; set; }
        [CustomField(AppTemplates.Post.Fields.Content, CustomFieldDataType.Html)]
        public string Content { get; set; }
        [CustomField(AppTemplates.Post.Fields.Featured, CustomFieldDataType.Bool)]
        public bool Featured { get; set; }
        [CustomField(AppTemplates.Post.Fields.Summary, CustomFieldDataType.String)]
        public string Summary { get; set; }
        [CustomField(AppTemplates.Post.Fields.Thumbnail, CustomFieldDataType.Image)]
        public string Thumbnail { get; set; }
        [CustomField(AppTemplates.Post.Fields.Title, CustomFieldDataType.String)]
        public string Title { get; set; }
    }
}
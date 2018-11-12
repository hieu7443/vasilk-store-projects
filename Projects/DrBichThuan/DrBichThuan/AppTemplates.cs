using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrBichThuan
{
    public static class AppTemplates
    {
        public struct ContactDetail
        {
            public static Guid ID { get { return new Guid("491a749c-09ca-47f5-a9a9-96bc6061434c"); } }
            public struct Fields
            {
                public const string Address = "6cfc056a-ff64-4573-9ab1-862f9babf794";
                public const string Description = "91c1f07a-a4ba-4464-b04e-4e2e575b05ef";
                public const string Logo = "aca2d562-fa81-4fd4-b1ba-e2c2e5bf7acd";
                public const string MapLocation = "ba50843c-a669-4600-8cfe-5d9cae9636c7";
                public const string Name = "0d820635-3879-4ca4-85ab-58f7a9d2cd8f";
                public const string Phone = "e7c0615d-3221-4e42-b073-eb2908bf8213";
                public const string SubTitle = "a39cbe99-7b35-4b25-b203-1d67596eabfa";
                public const string Title = "607aec88-3409-4aec-a3e4-532aa4cc5a84";
                public const string WorkHours = "84f6b83c-9709-48fe-b14f-6da7e443497f";
                public const string Thumbnail = "957dd92b-698c-4811-8185-c4d1ea5f28b4";
                public const string Url = "70fd4a70-49a1-4b18-88f4-f3f7b75daf77";
            }
        }
        public struct WorkHour
        {
            public static Guid ID { get { return new Guid("468c04b3-21c2-4b3a-9650-eb84cdeb2a5e"); } }
            public struct Fields
            {
                public const string Day = "e99c2d59-8796-412f-bd31-4b5d97e1af1f";
                public const string Time = "23785d0d-b864-4ecb-b5f9-2c5513c5de4d";
                public const string Index = "b6fa07e9-6a9d-45ba-9426-614ae19d467c";
            }
        }
        public struct MenuItem
        {
            public static Guid ID { get { return new Guid("793e4c24-971e-4d56-950f-2fd60fb4e24e"); } }
            public struct Fields
            {
                public const string Index = "d85e6f74-91f1-4bb5-8d37-1eab9709583f";
                public const string Title = "063baca5-8306-4bf1-b33e-d3eaca1147d1";
                public const string Url = "afd95cdc-f8e3-4b85-9f6c-dd30cfbb0c9d";
            }
        }
        public struct Page
        {
            public static Guid ID { get { return new Guid("ffd2502a-0883-4078-b55b-020818121ed0"); } }
            public struct Fields
            {
                public const string Icon = "f7680ee7-0eb0-45fa-ad8b-3a4175e82222";
                public const string MetaData = "73fb5e80-c411-48e7-b706-b3a63b4e10d0";
                public const string HideMapOnMobile = "87613321-815e-4ec1-9648-1583bc8f29e5";
            }
        }
        public struct Category
        {
            public static Guid ID { get { return new Guid("3ce83885-7251-41ab-9943-0a6e0a88daae"); } }
        }
        public struct Post
        {
            public static Guid ID { get { return new Guid("7fd49747-faa9-4c64-bc41-8a211c276d32"); } }
            public struct Fields
            {
                public const string Content = "3f665305-0db3-46c5-84a0-5585ff503f42";
                public const string Featured = "2244ebd3-1053-4dc4-8c0c-80bfa33c02b3";
                public const string Summary = "689f3d35-2340-413d-8712-ba9b1cc22a92";
                public const string Thumbnail = "67176156-818c-4c73-b3a5-b1558829e225";
                public const string Title = "1e93c4e3-720b-4f0d-9ae1-f0fd19911c54";
            }
        }
        public struct Contact
        {
            public static Guid ID { get { return new Guid("b441850e-be66-4af8-ac4e-a51bf05ee005"); } }
        }
        public struct Home
        {
            public static Guid ID { get { return new Guid("5f0dee1d-fa64-478b-b7d4-01e0ccf14889"); } }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class CommunityClass
    {
        public string community_category(string category_id)
        {
            switch (category_id)
            {
                case "1":
                    return "學習類社群";
                case "2":
                    return "運動類社群";
                case "3":
                    return "作息養成社群";
                case "4":
                    return "控制飲食社群";
                default:
                    return "";
            }
        }
    }
}
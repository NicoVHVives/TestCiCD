using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "[route-data=true]")]

    
    public class RouteDataTagHelper : TagHelper
    {
        public bool RouteData { get; set; } = true;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; } = new();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "bg-info m-2 p-2");

            TagBuilder list = new TagBuilder("ul");
            list.Attributes["class"] = "list-group";

            RouteValueDictionary rd = Context.RouteData.Values;

            if(rd.Count> 0)
            {
                foreach(var kv in rd)
                {
                    TagBuilder listItem = new TagBuilder("li");
                    listItem.Attributes["class"] = "list-item";
                    listItem.InnerHtml.Append($"{kv.Key} - {kv.Value}");

                    list.InnerHtml.AppendHtml(listItem);
                }
                output.Content.AppendHtml(list);
            }else
            {
                output.Content.Append("No Route Data");
            }
        }
    }
}

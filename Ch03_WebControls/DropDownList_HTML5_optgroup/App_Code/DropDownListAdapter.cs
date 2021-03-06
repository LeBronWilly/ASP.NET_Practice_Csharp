using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;

    // ***資料來源***  http://www.codeproject.com/Articles/15505/ASP-NET-DropDownList-with-OptionGroup-support

    public class DropDownListAdapter : System.Web.UI.WebControls.Adapters.WebControlAdapter {
        protected override void RenderContents(HtmlTextWriter writer) {
            DropDownList list = this.Control as DropDownList;

            string currentOptionGroup;
            List<string> renderedOptionGroups = new List<string>();

            foreach(ListItem item in list.Items) {
                if(item.Attributes["OptionGroup"] == null) {
                    RenderListItem(item, writer);    //直接產生 <option>子選項
                }                 
                else {
                    currentOptionGroup = item.Attributes["OptionGroup"];

                    if(renderedOptionGroups.Contains(currentOptionGroup)) {
                        RenderListItem(item, writer);
                    } else {
                        if(renderedOptionGroups.Count > 0) {
                            RenderOptionGroupEndTag(writer);
                        }

                        RenderOptionGroupBeginTag(currentOptionGroup, writer);
                        renderedOptionGroups.Add(currentOptionGroup);

                        RenderListItem(item, writer);
                    }
                }
            }

            if(renderedOptionGroups.Count > 0) {
                RenderOptionGroupEndTag(writer);
            }
        }
        //=================================================
        private void RenderOptionGroupBeginTag(string name, HtmlTextWriter writer) {
            writer.WriteBeginTag("optgroup");
            writer.WriteAttribute("label", name);
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
        }
        private void RenderOptionGroupEndTag(HtmlTextWriter writer) {
            writer.WriteEndTag("optgroup");
            writer.WriteLine();
        }

        //=================================================
        private void RenderListItem(ListItem item, HtmlTextWriter writer) {
            writer.WriteBeginTag("option");
            writer.WriteAttribute("value", item.Value, true);

            if(item.Selected) {
                writer.WriteAttribute("selected", "selected", false);
            }

            //foreach(string key in item.Attributes.Keys) {
            //    writer.WriteAttribute(key, item.Attributes[key]);
            //}

            writer.Write(HtmlTextWriter.TagRightChar);
            HttpUtility.HtmlEncode(item.Text, writer);
            writer.WriteEndTag("option");
            writer.WriteLine();
        }
    }

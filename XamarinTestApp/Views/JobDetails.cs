#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fielder
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class JobDetails : JobDetailsBase
{

#line hidden

#line 1 "JobDetails.cshtml"
public JobData Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<html>\r\n\t<head>\r\n\t\t<link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"jquery.mobile-1.4.5.min.css\"");

WriteLiteral(" />\r\n\t\t<!--<link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"ImageTiles.css\"");

WriteLiteral(" />-->\r\n\t\t<link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"style.css\"");

WriteLiteral(" />\r\n\t\t<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"jquery.jsf\"");

WriteLiteral("></script>\r\n\t\t<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"jquery.mobile-1.4.5.jsf\"");

WriteLiteral("></script>\r\n\t\t<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"jquery.linq.min.js\"");

WriteLiteral("></script>\r\n\t\t<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\t\t\t\r\n\t\t\tvar Enumerable;\r\n\t\t\tvar jobsJsonString = \"");


#line 13 "JobDetails.cshtml"
                     Write(Model.JSON);


#line default
#line hidden
WriteLiteral(@""";
			var job=null;
			var KeyValue = new function() {
				this.key = """";
				this.value = """";
			}
			var LeadGen= new function() {
				this._id="""";
				this.index=0;
			    this.firstName= """";
			    this.lastName="""";    
			    this.addressL1="""";
			    this.addressL2="""";
			    this.city="""";
			    this.postcode="""";
			    this.telephone="""";
			    this.email="""";
			    this.keyvalue=new Array();
			    this.notes="""";
			    this.bookedBy="""";
			}

			$(function() {				
				console.log(""start"");
				Enumerable = $.Enumerable;
			     //GetJobData(""");


#line 38 "JobDetails.cshtml"
                  Write(Model._id);


#line default
#line hidden
WriteLiteral("\");\r\n\t\t\t     if (jobsJsonString != \"\") {\t\t\t\t     \t\r\n\t\t\t     \tjobsJsonString = job" +
"sJsonString.replace(/\\n/g, \' \');\r\n\t\t\t\t\tjobsJsonString = jobsJsonString.replace(/" +
"&quot;/g, \'\"\');\r\n\t\t\t\t\tjob = JSON.parse(jobsJsonString);\r\n\t\t\t\t\tupdateData(job);\r\n" +
"\t\t\t\t} else {\r\n\t\t\t\t\tjob = LeadGen;\r\n\t\t\t\t\tconsole.log(JSON.stringify(job));\r\n\t\t\t\t\t" +
"updateData(job);\r\n\t\t\t\t}\r\n\t\t\t\t/*if(job._id != \"\") {\r\n\t\t\t\t\t$(\"#target :input\").pro" +
"p(\"disabled\", true);\r\n\t\t\t\t\t$(\"#okBtn\").show();\t\t\t\t\r\n\t\t\t\t} else\r\n\t\t\t\t\t$(\"#okBtn\")" +
".hide();*/\r\n\r\n\t\t\t });\r\n\r\n\t\t\t// This javascript method calls C# by setting the br" +
"owser \r\n\t\t\t// to a URL with a custom scheme that is registered in C#.  \r\n\t\t\t// A" +
"ll values are sent to C# as part of the querystring  \r\n\t\t\tfunction InvokeCSharpW" +
"ithFormValues(elm) {\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\tvar qs = \"\";\r\n\t\t\t\tvar elms = elm.form.ele" +
"ments;\r\n\r\n\t\t\t\tfor (var i = 0; i < elms.length;i++) {\r\n\t\t\t\t\tqs += \"&\" + elms[i].n" +
"ame + \"=\" + elms[i].value;\r\n\t\t\t\t}\r\n\r\n\t\t\t\tif (elms.length > 0) \r\n\t\t\t\t\tqs = qs.sub" +
"string(1);\r\n\r\n\t\t\t\tlocation.href = \"hybrid:\" + elm.name + \"?\" + qs;\r\n\t\t\t}\r\n\r\n\t\t\tf" +
"unction InvokeCSharpWithElementValues(elm, stage) {\t\r\n\t\t\t\t$(\'#jobDetails input[t" +
"ype=text]\').each(function(i) {\t\t\t    \t\r\n\t\t    \t job[this.id] = this.value;\r\n\t\t  " +
"    \t});\r\n\r\n\t\t      \t$.each( keyFields, function( index, keyname ) {\r\n\t\t\t\t  \tvar" +
" kv = new Object();\t\t\t\t\t\r\n\t\t      \t\tkv.key = keyname;\r\n\t\t      \t\tkv.value = $(\'#" +
"\' + keyname).val();;\r\n\t\t      \t\tconsole.log(kv.key);\r\n\t\t    \t \tjob.keyvalue.push" +
"(kv);\r\n\t\t\t\t});\r\n\r\n\t\t\t\tjob.stage = stage;\r\n\t\t      \tconsole.log(JSON.stringify(jo" +
"b));\r\n\t\t\t\tvar qs = \"\";\r\n\t\t\t\tqs += \"_id=");


#line 90 "JobDetails.cshtml"
           Write(Model._id);


#line default
#line hidden
WriteLiteral("\";\r\n\t\t\t\tqs += \"&json=\" + JSON.stringify(job);\r\n\t\t\t\tlocation.href = \"hybrid:\" + el" +
"m.name + \"?\" + qs;\r\n\t\t\t}\r\n\t\t\t\t\t\t\r\n\r\n\t\t\t// This javascript method is called from " +
"C#\r\n\t\t\tfunction SetLabelText(text) {\t\t\t\t\r\n\t\t\t\tvar elm =  $(\"#label\"); //document" +
".getElementById(\'label\');\r\n\t\t\t\t//alert(elm);\r\n\t\t\t\telm.text(text);\r\n\t\t\t}\t\t\t\t\r\n\r\n\t" +
"\t\tfunction GetInputDiv(id, placeholder, value) {\r\n\t\t\t\treturn \"<input type=\'text\'" +
" data-clear-btn=\'true\' id=\'\" + id + \"\' placeholder=\'\" + placeholder + \"\' value=\'" +
"\" + value + \"\' />\"\r\n\t\t\t}\r\n\t\t\tfunction updateData(stringifiedTable) {\r\n\r\n\t\t\t    v" +
"ar tbody = $(\"#jobDetails\");\r\n\t\t\t    var row = stringifiedTable;\r\n\r\n\t\t\t    var h" +
"tml = \"\";\r\n\t\t\t        \t\t\t    \t\t        \t\t\t    \t\t\t\t\t\t\t\t      \t\t        \t\t       \r" +
"\n\t\t        html = html + GetInputDiv(\"firstName\", \'First Name\', row.firstName);\r" +
"\n\t\t\t\thtml = html + GetInputDiv(\"lastName\", \'Last Name\', row.lastName);\r\n\t\t\t\thtml" +
" = html + GetInputDiv(\"addressL1\", \'Address Line 1\', row.addressL1);\r\n\t\t\t\thtml =" +
" html + GetInputDiv(\"addressL2\", \'Address Line 2\', row.addressL2);\r\n\t\t\t\thtml = h" +
"tml + GetInputDiv(\"city\", \'City\', row.city);\r\n\t\t\t\thtml = html + GetInputDiv(\"pos" +
"tcode\", \'Postcode\', row.postcode);\r\n\t\t\t\thtml = html + GetInputDiv(\"telephone\", \'" +
"Telephone\', row.telephone);\r\n\t\t\t\thtml = html + GetInputDiv(\"email\", \'Email\', row" +
".email);\r\n\r\n\t\t\t    tbody.append(html).enhanceWithin();\r\n\t\t\t    //$(\"#tableJobs\")" +
".table(\"refresh\");\r\n\r\n\t\t\t    $.each( keyFields, function(index, keyname) {\r\n\t\t\t " +
"   \t$(\"#\" + keyname).val(Enumerable.From(row.keyvalue).Where(function(x) {return" +
" x.key == keyname}).First().value);\r\n\t\t\t    });\r\n\t\t\t    //updateLeadTypes(row)\r\n" +
"\t\t\t}\t\t\t\t    \r\n\t\t\tvar keyFields = [\"boiler_type_c\", \"boiler_size_c\", \"flue_type_c" +
"\", \"boiler_access_c\", \"boiler_age_c\", \"boiler_location_c\", \"boiler_rating_c\", \"n" +
"umber_of_radiators_c\", \"number_of_rooms_c\", \"number_of_valves_c\", \"pipework_c\", " +
"\"thermostat_valves_c\", \"thermostat_location_c\", \"location_of_stopcock_valve_c\", " +
"\"location_of_meter_c\", \"type_of_meter_c\", \"type_of_property_c\", \"access_to_prope" +
"rty_c\", \"parking_access_c\"];\r\n\t\t</script>\r\n\t</head>\r\n\t<body>\t\t\r\n\t\t<div");

WriteLiteral(" data-role=\"page\"");

WriteLiteral(" data-theme=\"b\"");

WriteLiteral(">\t\t\r\n\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"\"");

WriteLiteral(">\r\n\t\t\t<div");

WriteLiteral(" data-role=\"header\"");

WriteLiteral(">\r\n\t\t\t\t<h1>New Lead</h1>\t\t\t\r\n\t\t\t\t<a");

WriteLiteral(" name=\"CompleteJob\"");

WriteLiteral(" id=\"okBtn\"");

WriteLiteral(" onclick=\"InvokeCSharpWithElementValues(this, 0)\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"ui-btn-right ui-btn ui-btn-b ui-btn-inline ui-mini ui-corner-all ui-btn-i" +
"con-right ui-icon-check\"");

WriteLiteral(">Save</a>    \r\n\t\t\t</div>\t\r\n\t\t\t<form");

WriteLiteral(" id=\"target\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" data-role=\"collapsibleset\"");

WriteLiteral(" data-theme=\"b\"");

WriteLiteral(" data-content-theme=\"b\"");

WriteLiteral(">\r\n\t\t\t\t    <div");

WriteLiteral(" data-role=\"collapsible\"");

WriteLiteral(">\r\n\t\t\t\t    \t<h2>Lead Details</h2>\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"ui-grid-solo\"");

WriteLiteral(" id=\"jobDetails\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div");

WriteLiteral(" data-role=\"collapsible\"");

WriteLiteral(">\r\n    \t\t\t\t\t<h2>Boiler Details</h2>\t\t\t\t  \t \t\t\t\t\t  \r\n    \t\t\t\t\t<div");

WriteLiteral(" class=\"ui-grid-solo\"");

WriteLiteral(" id=\"boilerDetails\"");

WriteLiteral(">\r\n    \t\t\t\t\t\t<select");

WriteLiteral(" id=\"boiler_type_c\"");

WriteLiteral(">\r\n\t\t\t\t\t\t        <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">Boiler Type...</option>\r\n\t\t\t\t\t            <option");

WriteLiteral(" value=\"system\"");

WriteLiteral(">System</option>\r\n\t\t\t\t\t            <option");

WriteLiteral(" value=\"combi\"");

WriteLiteral(">Combi</option>\r\n\t\t\t\t\t\t    </select>\r\n    \t\t\t\t\t\t<input");

WriteLiteral(" type=\'text\'");

WriteLiteral(" data-clear-btn=\'true\'");

WriteLiteral(" id=\'boiler_size_c\'");

WriteLiteral(" placeholder=\'Boiler Size\'");

WriteLiteral(" value=\'\'");

WriteLiteral(" />\r\n    \t\t\t\t\t\t<select");

WriteLiteral(" id=\"flue_type_c\"");

WriteLiteral(">\r\n\t\t\t\t\t\t        <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">Flue Type...</option>\r\n\t\t\t\t\t            <option");

WriteLiteral(" value=\"Vertical\"");

WriteLiteral(">Vertical</option>\r\n\t\t\t\t\t            <option");

WriteLiteral(" value=\"Horizontal\"");

WriteLiteral(">Horizontal</option>\r\n\t\t\t\t\t\t    </select>\r\n\t\t\t\t\t\t\t<select");

WriteLiteral(" id=\"boiler_access_c\"");

WriteLiteral(">\r\n\t\t\t\t\t\t        <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">Boiler Access...</option>\r\n\t\t\t\t\t            <option");

WriteLiteral(" value=\"confined\"");

WriteLiteral(">Confined</option>\r\n\t\t\t\t\t            <option");

WriteLiteral(" value=\"easy\"");

WriteLiteral(">Easy</option>\r\n\t\t\t\t\t\t    </select>\r\n\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\'text\'");

WriteLiteral(" data-clear-btn=\'true\'");

WriteLiteral(" id=\'boiler_age_c\'");

WriteLiteral(" placeholder=\'Boiler Age\'");

WriteLiteral(" value=\'\'");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\'text\'");

WriteLiteral(" data-clear-btn=\'true\'");

WriteLiteral(" id=\'boiler_location_c\'");

WriteLiteral(" placeholder=\'Boiler Location\'");

WriteLiteral(" value=\'\'");

WriteLiteral(" />\r\n\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\'text\'");

WriteLiteral(" data-clear-btn=\'true\'");

WriteLiteral(" id=\'boiler_rating_c\'");

WriteLiteral(" placeholder=\'Boiler Rating\'");

WriteLiteral(" value=\'\'");

WriteLiteral(" />\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t  \t</div>\t\t\t\t\t   \r\n\t\t\t\t  \t<!-- thermostat_valves_c\", \"ther" +
"mostat_location_c\", \"location_of_stopcock_valve_c\", \"location_of_meter_c\" -->\r\n\t" +
"\t\t\t  \t<div data-role=\"collapsible\">\r\n    \t\t\t\t\t<h2>System Details</h2>\t\t\t\t  \t \t\t\t" +
"\t\t  \r\n    \t\t\t\t\t<div class=\"ui-grid-solo\" id=\"systemDetails\">\r\n    \t\t\t\t\t\t<input t" +
"ype=\'text\' data-clear-btn=\'true\' id=\'number_of_radiators_c\' placeholder=\'No. of " +
"Radiators\' value=\'\' />\r\n    \t\t\t\t\t\t<input type=\'text\' data-clear-btn=\'true\' id=\'n" +
"umber_of_rooms_c\' placeholder=\'No. of Rooms\' value=\'\' />\r\n    \t\t\t\t\t\t<input type=" +
"\'text\' data-clear-btn=\'true\' id=\'number_of_valves_c\' placeholder=\'No. of Valves\'" +
" value=\'\' />\r\n    \t\t\t\t\t\t<input type=\'text\' data-clear-btn=\'true\' id=\'pipework_c\'" +
" placeholder=\'Pipework\' value=\'\' />\r\n    \t\t\t\t\t\t<input type=\'text\' data-clear-btn" +
"=\'true\' id=\'thermostat_valves_c\' placeholder=\'Thermostat Valves\' value=\'\' />\r\n  " +
"  \t\t\t\t\t\t<input type=\'text\' data-clear-btn=\'true\' id=\'thermostat_location_c\' plac" +
"eholder=\'Thermostat Location\' value=\'\' />\r\n    \t\t\t\t\t\t<input type=\'text\' data-cle" +
"ar-btn=\'true\' id=\'location_of_stopcock_valve_c\' placeholder=\'Location of Stopcoc" +
"k Valve\' value=\'\' />    \t\t\t\t\t\t\t\t\t\t\t\r\n    \t\t\t\t\t\t<input type=\'text\' data-clear-btn" +
"=\'true\' id=\'location_of_meter_c\' placeholder=\'Location of Meter\' value=\'\' />\r\n  " +
"  \t\t\t\t\t\t<select id=\"type_of_meter_c\">\r\n\t\t\t\t\t\t        <option value=\"\">Type of Me" +
"ter...</option>\r\n\t\t\t\t\t            <option value=\"prepaid\">Prepaid</option>\r\n\t\t\t\t" +
"\t            <option value=\"standard\">Standard</option>\r\n\t\t\t\t\t\t    </select>\r\n\t\t" +
"\t\t\t\t</div>\r\n\t\t\t\t  \t</div>\r\n\t\t\t\t  \t<!--  \"type_of_property_c\", \"access_to_propert" +
"y_c\", \"parking_access_c\" -->\r\n\t\t\t\t  \t<div data-role=\"collapsible\">\r\n    \t\t\t\t\t<h2" +
">Property Details</h2>\t\t\t\t  \t \t\t\t\t\t  \r\n    \t\t\t\t\t<div class=\"ui-grid-solo\" id=\"pr" +
"opertyDetails\">    \t\t\t\t\t\t\r\n    \t\t\t\t\t\t<select id=\"type_of_property_c\">\r\n\t\t\t\t\t\t   " +
"     <option value=\"\">Type of Property...</option>\r\n\t\t\t\t\t            <option val" +
"ue=\"house\">House</option>\r\n\t\t\t\t\t            <option value=\"flat\">Flat</option>\r\n" +
"\t\t\t\t\t            <option value=\"bungalow\">Bungalow</option>\r\n\t\t\t\t\t\t    </select>" +
"\r\n\t\t\t\t\t\t\t<select id=\"access_to_property_c\">\r\n\t\t\t\t\t\t        <option value=\"\">Acce" +
"ss to Property...</option>\r\n\t\t\t\t\t            <option value=\"restricted\">Restrict" +
"ed</option>\r\n\t\t\t\t\t            <option value=\"unrestricted\">Unrestricted</option>" +
"\r\n\t\t\t\t\t\t    </select>\r\n\t\t\t\t\t\t\t<select id=\"parking_access_c\">\r\n\t\t\t\t\t\t        <opt" +
"ion value=\"\">Parking Access...</option>\r\n\t\t\t\t\t            <option value=\"restric" +
"ted\">Restricted</option>\r\n\t\t\t\t\t            <option value=\"unrestricted\">Unrestri" +
"cted</option>\r\n\t\t\t\t\t\t    </select>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t  \t</div>\r\n\t\t\t\t</div>\r\n\t\t\t" +
"\t<div id=\"AfterJobHasStarted\">\t\t\t\t\t\t  \r\n\t\t\t\t\t<input type=\"button\" name=\"Complete" +
"Job\" value=\"Update CRM\" onclick=\"InvokeCSharpWithElementValues(this, 1)\" />\r\n\t\t\t" +
"\t</div>\r\n\r\n\t\t\t</form>\r\n\t\t</div>\t\t\t\t\r\n\t</body>\r\n</html>\t\r\n\r\n\r\n");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class JobDetailsBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the 
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591

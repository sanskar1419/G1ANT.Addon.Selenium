/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using G1ANT.Language;
using System;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.gethtml", Tooltip = "This command gets full Html of a web page")]

    public class SeleniumGetHtmlCommand : Command
    {
        public class Arguments : SeleniumIFrameArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Name of a variable where the outer html of a specified element will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public SeleniumGetHtmlCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                var attributeValue = SeleniumManager.CurrentWrapper.GetHtml(
                arguments);

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new HtmlStructure(attributeValue));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unable to get Html web source. Message: {ex.Message}", ex);
            }
        }
    }
}

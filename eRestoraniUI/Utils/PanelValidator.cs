using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.Utils
{
    public static class ValidatorHelper
    {
        public static bool ValidateChildren(ContainerControl containerToBeValidated, Control doNotValidate, Control doValidate)
        {
            // Isključi validaciju za navedenu kontrolu/kontrole
            try
            {
                if (!doNotValidate.HasChildren)
                {
                    doNotValidate.CausesValidation = false;
                }
                else
                {
                    foreach (Control control in doNotValidate.Controls) 
                    //foreach (TextBox control in doNotValidate.Controls.OfType<TextBox>()) // validiraj samo TextBox kontrole, jer radimo validaciju samo na njima
                    {
                        control.CausesValidation = false;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                // preskoči ako je kontrola null
            }

            // Uključi validaciju za navedenu kontrolu/kontrole
            try
            {
                if (!doValidate.HasChildren)
                {
                    doValidate.CausesValidation = true;
                }
                else
                {
                    foreach (Control control in doValidate.Controls) 
                    //foreach (TextBox control in doValidate.Controls.OfType<TextBox>()) // validiraj samo TextBox kontrole, jer radimo validaciju samo na njima
                    {
                        control.CausesValidation = true;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                // preskoči ako je kontrola null
            }

            return containerToBeValidated.ValidateChildren();
        }
    }
}

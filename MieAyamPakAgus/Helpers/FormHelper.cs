using System;
using System.Drawing;
using System.Windows.Forms;

namespace MieAyamPakAgus.Helpers
{
    public static class FormHelper
    {
        private static readonly Color ErrorColor = Color.LightCoral;
        private static readonly Color NormalColor = Color.White;

        public static void HighlightError(Control ctrl, bool isError)
        {
            if (ctrl is TextBox txt)
            {
                txt.BackColor = isError ? ErrorColor : NormalColor;
            }
            else if (ctrl is ComboBox cmb)
            {
                cmb.BackColor = isError ? ErrorColor : NormalColor;
            }
        }

        public static void ClearErrors(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                HighlightError(ctrl, false);
                if (ctrl.HasChildren)
                    ClearErrors(ctrl);
            }
        }

        public static void ClearFormControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                    txt.BackColor = NormalColor;
                }
                else if (ctrl is ComboBox cmb)
                {
                    if (cmb.Items.Count > 0 && cmb.DropDownStyle == ComboBoxStyle.DropDownList)
                        cmb.SelectedIndex = 0;
                    else
                        cmb.SelectedIndex = -1;
                    cmb.BackColor = NormalColor;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Today;
                }
                else if (ctrl is NumericUpDown nud)
                {
                    nud.Value = nud.Minimum;
                }
                else if (ctrl is PictureBox pic)
                {
                    if (pic.Image != null)
                    {
                        pic.Image.Dispose();
                        pic.Image = null;
                    }
                }

                if (ctrl.HasChildren)
                    ClearFormControls(ctrl);
            }
        }

        public static Control FindFirstErrorControl(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt && txt.BackColor == ErrorColor)
                    return txt;
                if (ctrl is ComboBox cmb && cmb.BackColor == ErrorColor)
                    return cmb;
                if (ctrl.HasChildren)
                {
                    Control found = FindFirstErrorControl(ctrl);
                    if (found != null) return found;
                }
            }
            return null;
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

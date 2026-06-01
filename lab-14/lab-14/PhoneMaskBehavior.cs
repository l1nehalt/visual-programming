using System;
using Xamarin.Forms;

namespace lab_14
{
    public class PhoneMaskBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var text = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(text)) return;

            var digits = string.Empty;
            foreach (var ch in text)
            {
                if (char.IsDigit(ch)) digits += ch;
            }

            if (digits.Length > 11)
            {
                digits = digits.Substring(0, 11);
            }

            var formatted = string.Empty;

            if (digits.Length > 0)
            {
                formatted += "+7 ";

                int startIdx = (digits[0] == '7' || digits[0] == '8') ? 1 : 0;

                var remainingDigits = digits.Substring(startIdx);

                if (remainingDigits.Length > 0)
                {
                    formatted += "(" + remainingDigits.Substring(0, Math.Min(3, remainingDigits.Length));
                }
                if (remainingDigits.Length > 3)
                {
                    formatted += ") " + remainingDigits.Substring(3, Math.Min(3, remainingDigits.Length - 3));
                }
                if (remainingDigits.Length > 6)
                {
                    formatted += "-" + remainingDigits.Substring(6, Math.Min(2, remainingDigits.Length - 6));
                }
                if (remainingDigits.Length > 8)
                {
                    formatted += "-" + remainingDigits.Substring(8, Math.Min(2, remainingDigits.Length - 8));
                }
            }

            if (entry.Text != formatted)
            {
                entry.Text = formatted;
            }
        }
    }
}
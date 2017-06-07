using QSF.Controls;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace QSF.CodeFormatting
{
    public class CodeViewer : Control
    {
        public static readonly DependencyProperty WordWrapProperty =
            DependencyProperty.Register("WordWrap", typeof(bool), typeof(CodeViewer), new PropertyMetadata(false));

        public static readonly DependencyProperty HScrollVisibilityProperty =
            DependencyProperty.Register("HScrollVisibility", typeof(ScrollBarVisibility), typeof(CodeViewer), new PropertyMetadata(ScrollBarVisibility.Auto));

        public static readonly DependencyProperty VScrollVisibilityProperty =
            DependencyProperty.Register("VScrollVisibility", typeof(ScrollBarVisibility), typeof(CodeViewer), new PropertyMetadata(ScrollBarVisibility.Auto));

        // Using a DependencyProperty as the backing store for Filename.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilenameProperty =
            DependencyProperty.Register("Filename", typeof(string), typeof(CodeViewer), new PropertyMetadata(string.Empty, OnFilenameOrCodePropertyChanged));

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(CodeViewer), new PropertyMetadata(null, OnFilenameOrCodePropertyChanged));

        private bool isLoaded;
        private bool isTemplateApplied;
        private StackPanel panel;
        private bool needsUpdate = false;

        public CodeViewer()
        {
            this.DefaultStyleKey = typeof(CodeViewer);

            this.LayoutUpdated += this.OnLayoutUpdated;
        }

        public ScrollBarVisibility HScrollVisibility
        {
            get
            {
                return (ScrollBarVisibility)this.GetValue(HScrollVisibilityProperty);
            }
            set
            {
                this.SetValue(HScrollVisibilityProperty, value);
            }
        }

        public ScrollBarVisibility VScrollVisibility
        {
            get
            {
                return (ScrollBarVisibility)this.GetValue(VScrollVisibilityProperty);
            }
            set
            {
                this.SetValue(VScrollVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Determines whether the internally used TextBlock will use text wrapping.
        /// </summary>
        public bool WordWrap
        {
            get
            {
                return (bool)this.GetValue(WordWrapProperty);
            }
            set
            {
                this.SetValue(WordWrapProperty, value);
            }
        }

        public string Code
        {
            get { return (string)this.GetValue(CodeProperty); }
            set { this.SetValue(CodeProperty, value); }
        }

        public string Filename
        {
            get { return (string)this.GetValue(FilenameProperty); }
            set { this.SetValue(FilenameProperty, value); }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.panel = this.GetTemplateChild("PART_Panel") as StackPanel;
            this.isTemplateApplied = true;
            this.TryBuildTextBlocks();
        }

        private static void OnFilenameOrCodePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var codeViewer = d as CodeViewer;
            if (codeViewer.needsUpdate)
            {
                codeViewer.TryBuildTextBlocks();
            }
            else
            {
                codeViewer.needsUpdate = true;
            }
        }

        private static string GetFilenameExtensionWithLeadingDot(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return string.Empty;
            }

            return filename.Substring(filename.LastIndexOf("."));
        }

        private void OnLayoutUpdated(object sender, object e)
        {
            this.isLoaded = true;

            if (!this.isTemplateApplied)
            {
                return;
            }

            this.LayoutUpdated -= this.OnLayoutUpdated;

            this.TryBuildTextBlocks();
        }

        private RichTextBlock CreateTextBlock()
        {
            RichTextBlock block = new RichTextBlock();
            block.HorizontalAlignment = HorizontalAlignment.Stretch;
            block.VerticalAlignment = VerticalAlignment.Stretch;

            if (this.WordWrap)
            {
                block.TextWrapping = TextWrapping.Wrap;
            }


            return block;
        }

        private void TryBuildTextBlocks()
        {
            if (!this.isTemplateApplied || !this.isLoaded || string.IsNullOrEmpty(this.Filename) || string.IsNullOrEmpty(this.Code))
            {
                return;
            }

            Tokenizer tokenizer = new Tokenizer();
            RichTextBlock textBlock = this.CreateTextBlock();

            var paragraph = new Paragraph();
            foreach (Token token in tokenizer.TokenizeCode(this.Code, CodeViewer.GetFilenameExtensionWithLeadingDot(this.Filename)))
            {
                paragraph.Inlines.Add(token.GetInline());
            }

            textBlock.Blocks.Add(paragraph);

            this.needsUpdate = false;

            this.panel.Children.Clear();
            this.panel.Children.Add(textBlock);
        }
    }
}

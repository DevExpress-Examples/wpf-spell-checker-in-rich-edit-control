using DevExpress.Xpf.RichEdit;
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraRichEdit.SpellChecker;
using DevExpress.XtraSpellChecker;
using DevExpress.XtraSpellChecker.Native;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;

namespace RichEditSpellChecker_Example {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly SpellChecker _spellChecker;
        public MainWindow() {
            SpellCheckTextControllersManager.Default.RegisterClass(typeof(RichEditControl), typeof(RichEditSpellCheckController));
            InitializeComponent();
            _spellChecker = new SpellChecker();
            InitSpellChecker();
            richTextEdit.SpellChecker = _spellChecker;
        }
        private void InitSpellChecker()
        {
            _spellChecker.Culture = new System.Globalization.CultureInfo("en-US");
            _spellChecker.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;

            Stream dict_en_US = Assembly.GetExecutingAssembly().
   GetManifestResourceStream("RichEditSpellChecker_Example.Dictionaries.en_US.dic");
            Stream grammar_en_US = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("RichEditSpellChecker_Example.Dictionaries.en_US.aff");

            HunspellDictionary hunspellDictionaryEnglish = new HunspellDictionary();
            hunspellDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US);
            hunspellDictionaryEnglish.Culture = new CultureInfo("en-US");
            _spellChecker.Dictionaries.Add(hunspellDictionaryEnglish);

            SpellCheckerCustomDictionary customDictionary = new SpellCheckerCustomDictionary();
            customDictionary.AlphabetPath = @"Dictionaries\EnglishAlphabet.txt";
            customDictionary.DictionaryPath = @"Dictionaries\CustomEnglish.dic";
            customDictionary.Culture = new CultureInfo("en-US");
            _spellChecker.Dictionaries.Add(customDictionary);
        }
    }
}

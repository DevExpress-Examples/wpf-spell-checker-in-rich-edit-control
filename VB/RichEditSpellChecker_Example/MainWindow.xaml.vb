Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Windows

Namespace RichEditSpellChecker_Example
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Private ReadOnly _spellChecker As SpellChecker
		Public Sub New()
			InitializeComponent()
			_spellChecker = New SpellChecker()
			InitSpellChecker()
			richTextEdit.SpellChecker = _spellChecker
		End Sub
		Private Sub InitSpellChecker()
			_spellChecker.Culture = New System.Globalization.CultureInfo("en-US")
			_spellChecker.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType

			Dim dict_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Dictionaries.en_US.dic")
			Dim grammar_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Dictionaries.en_US.aff")

			Dim hunspellDictionaryEnglish As New HunspellDictionary()
			hunspellDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US)
			hunspellDictionaryEnglish.Culture = New CultureInfo("en-US")
			_spellChecker.Dictionaries.Add(hunspellDictionaryEnglish)

			Dim customDictionary As New SpellCheckerCustomDictionary()
			customDictionary.AlphabetPath = "Dictionaries\EnglishAlphabet.txt"
			customDictionary.DictionaryPath = "Dictionaries\CustomEnglish.dic"
			customDictionary.Culture = New CultureInfo("en-US")
			_spellChecker.Dictionaries.Add(customDictionary)
		End Sub
	End Class
End Namespace

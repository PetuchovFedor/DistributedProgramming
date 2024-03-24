using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Valuator.Repository;
using System;
namespace Valuator.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITextRepository _textRepository;
    public IndexModel(ILogger<IndexModel> logger, ITextRepository textRepository)
    {
        _logger = logger;
        _textRepository = textRepository;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost(string text)
    {
        if (String.IsNullOrEmpty(text))
        {
            return Redirect("/");
        }
        _logger.LogDebug(text);

        string id = Guid.NewGuid().ToString();

        string textKey = "TEXT-" + id;
        _textRepository.Add(textKey, text);
        int countNonLettter = text.Count(ch => !Char.IsLetter(ch));       
        string rankKey = "RANK-" + id;
        double rank = (double)countNonLettter / text.Length;
        _textRepository.Add(rankKey, rank.ToString());
        string similarityKey = "SIMILARITY-" + id;
        int similarity = _textRepository.CheckSimilarity(textKey);
        _textRepository.Add(similarityKey, similarity.ToString());
        return Redirect($"summary?id={id}");
    }
}

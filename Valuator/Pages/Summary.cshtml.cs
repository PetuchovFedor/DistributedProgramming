using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Valuator.Repository;

namespace Valuator.Pages;
public class SummaryModel : PageModel
{
    private readonly ILogger<SummaryModel> _logger;
    private readonly ITextRepository _textRepository;
    public SummaryModel(ILogger<SummaryModel> logger, ITextRepository textRepository)
    {
        _logger = logger;
        _textRepository = textRepository;
    }

    public double Rank { get; set; }
    public double Similarity { get; set; }

    public void OnGet(string id)
    {
        _logger.LogDebug(id);
        Rank = Convert.ToDouble(_textRepository.Get("RANK-" + id));
        Similarity = Convert.ToDouble(_textRepository.Get("SIMILARITY-" + id));
    }
}

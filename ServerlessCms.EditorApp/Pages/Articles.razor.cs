﻿using Microsoft.AspNetCore.Components;
using ServerlessCms.DTO;
using ServerlessCms.EditorApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessCms.EditorApp.Pages
{
  public partial class Articles
  {
    [Inject]
    protected ArticleService ArticleService { get; set; }
    [Inject]
    protected NavigationManager NavigationManager { get; set; }
    private IEnumerable<Article> ArticleCollection { get; set; }

    protected override async Task OnInitializedAsync()
    {
      ArticleCollection = await ArticleService.GetArticles();
    }

    private void OnEditButtonClick(string id)
    {
      NavigationManager.NavigateTo($"editarticle/{id}");
    }

    private async Task OnPublishButtonClick(Article article)
    {
      await ArticleService.PublishArticle(article);
      NavigationManager.NavigateTo("articles", forceLoad: true);
    }

    private async Task OnDeleteButtonClick(Article article)
    {
      await ArticleService.DeleteArticle(article);
      NavigationManager.NavigateTo("articles", forceLoad: true);
    }

  }
}

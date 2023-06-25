﻿using Microsoft.AspNetCore.Mvc;
using PersonalData.Model;
using PersonalData.Business;
using PersonalData.Data.VO;

namespace PersonalData.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookBusiness _bookBusiness;

    public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
    {
        _logger = logger;
        _bookBusiness = bookBusiness;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_bookBusiness.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var book = _bookBusiness.FindById(id);

        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BookVO book)
    {
        if (book == null) return BadRequest();
        return Ok(_bookBusiness.Create(book));
    }

    [HttpPut]
    public IActionResult Put([FromBody] BookVO book)
    {
        if (book == null) return BadRequest();
        return Ok(_bookBusiness.Update(book));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _bookBusiness.Delete(id);
        return NoContent();
    }
}

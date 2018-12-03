$(".button-js-do").on("click",function()
{
    if ($(".dont").length)
    {
        $(".carousel").carousel('cycle');
        $('.button-js-do').removeClass('dont');
        $(".button-js-do").html('Freeze');
    }
    else 
    
    {
        $(".carousel").carousel("pause");
        $('.button-js-do').addClass('dont');
        $(".button-js-do").html('Unfreeze');
    };
    
}

)
;


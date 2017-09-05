$(document).ready(function() {

$('#bt').click(function(){
    $('nav.navbar.navbar-default').css({
        height: "300px"
    });
   
    
})

    
    $('figure img').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('#modal_form') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
    });
 
    
    $('#modal_close, #overlay').click( function(){
        $('#modal_form')
            .animate({opacity: 0, top: '45%'}, 200,  
                function(){ 
                    $(this).css('display', 'none'); 
                    $('#overlay').fadeOut(400); 
                }
            );
    });
    
    $('#modal_close, #overlay').click( function(){
        $('#modal_form')
            .animate({opacity: 0, top: '45%'}, 200,  
                function(){ 
                    $('.m1, .m2, .m3, .m4, .m5, .m6, .m7, .m8, .m9, .m10, .m11, .m12,.m13, .m14, .m15, .m16').css('display', 'none'); 
                    $('#overlay').fadeOut(400); 
                }
            );
    });
    
         $('figure .i1').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m1') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
   
             $('figure .i2').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m2') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i3').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m3') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });

     $('figure .i4').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m4') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
    
         $('figure .i5').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m5') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i6, .i6').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m6') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i7').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m7') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i8').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m8') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i9').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m9') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i10, .i10').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m10') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i11').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m11') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i12').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m12') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i13').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m13') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i14, .i14').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m14') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i15').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m15') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
         $('figure .i16').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('.m16') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
                 
    });
    
    $('.buy_now, .basket, .bs').click( function(event){
        event.preventDefault();
        $('#overlay').fadeIn(400, 
            function(){ 
                $('#modal_form_basket') 
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
        });
    });
 
    
    $('#modal_close, #overlay').click( function(){
        $('#modal_form_basket')
            .animate({opacity: 0, top: '45%'}, 200,  
                function(){ 
                    $(this).css('display', 'none'); 
                    $('#overlay').fadeOut(400); 
                }
            );
    });
    
    
    
    $('.catalog_menu, .product div').click(function(){
         $('#main').css('display', 'none');
         $('.about_us').css('display', 'none');
        $('.catalog').css('display', 'block'); 
    } )
    
    $('.main_menu').click(function(){
         $('#main').css('display', 'block');
        $('.about_us').css('display', 'none');
        $('.catalog').css('display', 'none'); 
    } )
    
    $('.about_us_menu').click(function(){
         $('#main').css('display', 'none');
        $('.about_us').css('display', 'block');
        $('.catalog').css('display', 'none'); 
    } )
    
    var $table = $('table.table-bordered'),
    $bodyCells = $table.find('.table-bordered tbody tr:first').children(),
    colWidth;

    $('.t-shird').click(function() {
        $('.color_choose').css('display', 'block');
        
});
    
    $(".beret").click(function(){
    $('.color_choose').css('display', 'none');
});
    $(".t-shird2").click(function(){
    $('.color_choose').css('display', 'none');
});
   

$(window).scroll(function(){
    if (document.body.scrollTop > 50) {
        $('.up').css('display', 'block');        
    };
    if (document.body.scrollTop < 50) {
        $('.up').css('display', 'none');        
    };
  });

 
   $('.up').click(function() {
    $('html, body').animate({scrollTop: 0},100);
    return false;
  })

    
});
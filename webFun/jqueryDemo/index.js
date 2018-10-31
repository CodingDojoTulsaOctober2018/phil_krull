$(document).ready(function(){
    console.log('working jquery');
    // alert('working jquery');
    $('button').click(function(){
        console.log('buttion clicked');
        var content = $('h1').text();
        console.log(content);
        $('h1').text('Goodbye');
    })
})
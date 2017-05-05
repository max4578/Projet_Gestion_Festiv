var top;
var resp;






function getHeader(type) {
    top = document.getElementById("top_navBar");
    resp = document.getElementById("navBar_Responsable");
    console.log("hello world");
    if (type == 'gestionFestival.Models.CResponsable') {
        show(top);
        show(resp);   
        
    }
}

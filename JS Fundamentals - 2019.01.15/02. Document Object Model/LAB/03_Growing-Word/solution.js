function solve(){
   let clicks = 0;
   document.querySelector('button').addEventListener('click',
   () => {
     let p = document.querySelector('#exercise p');
     if(clicks % 3 === 0){
       p.style.color = "blue";
     } else if (clicks % 3 === 1){
       p.style.color = "green";
     } else if(clicks % 3 === 2){
       p.style.color = "red";
     }
     clicks++;
     p.style.fontSize = `${clicks * 2}px`; });
 }
 
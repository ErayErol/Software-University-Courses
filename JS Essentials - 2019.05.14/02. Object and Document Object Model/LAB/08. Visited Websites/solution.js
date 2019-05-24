function solve() {
  let element = document.getElementsByClassName("link-1");

  for (let i = 0; i < element.length; i++) {
    let currentElement = element[i].getElementsByTagName("p")[0];
    console.log(currentElement);
    
    
  }
}
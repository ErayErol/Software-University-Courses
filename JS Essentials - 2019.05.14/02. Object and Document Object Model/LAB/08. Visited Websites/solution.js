function solve() {
  let siteElements = document.getElementsByClassName("link-1");
  console.log(siteElements);
  

  for (let siteElement of siteElements) {
    siteElement.addEventListener("click", function myFunc() {
      let paragraphElement = siteElement.getElementsByTagName("p")[0];
      let text = paragraphElement.textContent;
      let textParts = text.split(" ");
      let clicks = Number(textParts[1]);
      clicks++;

      textParts[1] = clicks;
      paragraphElement.textContent = textParts.join(" ");

      siteElement.removeEventListener("click", myFunc, false);
    });
  }
}
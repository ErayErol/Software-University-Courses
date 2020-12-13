async function getMyData() {
  return fetch(data)
}

let a;
try {
  let b = await getMyData()
  a = await b.json();

} catch (e) {
  console.log(error)
}

a;
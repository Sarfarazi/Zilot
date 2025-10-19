

const searchBoxToggle = () => {
  document.querySelector(".searchBox").classList.toggle("hidden")
}

const searchBar = document.querySelector(".searchBtn")
searchBar.addEventListener("click", searchBoxToggle)



const searchInput = document.getElementById("search")

searchInput.addEventListener("keyup", () => {
  if (event.target.value.trim() !== "") {
    searchHandler(event.target.value)
  }
})


const searchHandler = (value) => {
  fetch(`http://localhost:5067/search-products/${value.trim()}`)
    .then(res => res.json())
    .then(data => renderSearchResult(data))
}

const renderSearchResult = (res) => {
  let temp;
  if (res && res.data.length > 0) {
    temp = res.data.map(item => {
      return `<a href="/Product/${item.id}/${(item.zelutDetail.length>0) ? item.zelutDetail[0].id : ""}" class="p-3 w-full bg-gray-50 hover:bg-pastelGreen rounded-md mt-2 cursor-pointer">${item.nameModel}${(item.zelutDetail.length>0) ? "-" + item.zelutDetail[0].nameJadid : ""}</a>`
    }).join("")
    document.getElementById("searchResult").innerHTML = temp
  }else{
    document.getElementById("searchResult").innerHTML = '<p class="p-3 bg-gray-50 hover:bg-pastelGreen rounded-md mt-2 cursor-pointer">محصولی یافت نشد</p>'

  }
}
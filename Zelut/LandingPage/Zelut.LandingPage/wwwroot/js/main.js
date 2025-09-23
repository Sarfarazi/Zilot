const collectionTitles = document.querySelectorAll(".collection-title");
const collectionSubMenus = document.querySelectorAll(
  ".sidebar-collection-submenu-links"
);

const homeCategoryHandler = (category) => {
  document
    .querySelector(".currentCategory")
    .classList.remove("currentCategory");
  event.target.classList.add("currentCategory");
};

const scrollDown = () => {
  window.scrollTo({
    top: window.innerHeight * 0.8,
    behavior: "smooth",
  });
};

const scrollToTop = () => {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
};

const aboutHandler = (index) => {
  const about = [
    {
      title: "بینش ما",
      desc: "تعهد ما در زیلوت، تولید موکت‌هایی باکیفیت، بادوام و سازگار با محیط‌زیست است. ما خود را موظف می‌دانیم که با استفاده از مواد اولیه مرغوب، فناوری‌های روز و فرآیندهای تولید استاندارد، محصولاتی ارائه دهیم که نه‌تنها نیاز مشتریان را برآورده کند، بلکه تجربه‌ای دلپذیر و طولانی‌مدت برای آن‌ها ایجاد نماید. رضایت مشتریان، نوآوری در طراحی و مسئولیت‌پذیری در قبال جامعه و طبیعت، اصولی هستند که زیلوت در تمام مراحل کار به آن‌ها پایبند است.",
    },
    {
      title: "ماموریت ما",
      desc: "تعهد ما در زیلوت، تولید موکت‌هایی باکیفیت، بادوام و سازگار با محیط‌زیست است. ما خود را موظف می‌دانیم که با استفاده از مواد اولیه مرغوب، فناوری‌های روز و فرآیندهای تولید استاندارد، محصولاتی ارائه دهیم که نه‌تنها نیاز مشتریان را برآورده کند، بلکه تجربه‌ای دلپذیر و طولانی‌مدت برای آن‌ها ایجاد نماید. رضایت مشتریان، نوآوری در طراحی و مسئولیت‌پذیری در قبال جامعه و طبیعت، اصولی هستند که زیلوت در تمام مراحل کار به آن‌ها پایبند است.",
    },
    {
      title: "هدف ما",
      desc: "تعهد ما در زیلوت، تولید موکت‌هایی باکیفیت، بادوام و سازگار با محیط‌زیست است. ما خود را موظف می‌دانیم که با استفاده از مواد اولیه مرغوب، فناوری‌های روز و فرآیندهای تولید استاندارد، محصولاتی ارائه دهیم که نه‌تنها نیاز مشتریان را برآورده کند، بلکه تجربه‌ای دلپذیر و طولانی‌مدت برای آن‌ها ایجاد نماید. رضایت مشتریان، نوآوری در طراحی و مسئولیت‌پذیری در قبال جامعه و طبیعت، اصولی هستند که زیلوت در تمام مراحل کار به آن‌ها پایبند است.",
    },
    {
      title: "تعهد ما",
      desc: "تعهد ما در زیلوت، تولید موکت‌هایی باکیفیت، بادوام و سازگار با محیط‌زیست است. ما خود را موظف می‌دانیم که با استفاده از مواد اولیه مرغوب، فناوری‌های روز و فرآیندهای تولید استاندارد، محصولاتی ارائه دهیم که نه‌تنها نیاز مشتریان را برآورده کند، بلکه تجربه‌ای دلپذیر و طولانی‌مدت برای آن‌ها ایجاد نماید. رضایت مشتریان، نوآوری در طراحی و مسئولیت‌پذیری در قبال جامعه و طبیعت، اصولی هستند که زیلوت در تمام مراحل کار به آن‌ها پایبند است.",
    },
  ];
  document.getElementById("aboutTitle").textContent = about[index].title;
  document.getElementById("aboutDesc").textContent = about[index].desc;

  document.querySelector(".currentAbout").classList.remove("currentAbout");
  event.target.classList.add("currentAbout");
};

const changeColorHandler = () => {
  document.querySelector(".currentColor").classList.remove("currentColor");
  event.target.classList.add("currentColor");
};

const productCategoryHandler = () => {
  document
    .querySelector(".currentProductCat")
    .classList.remove("currentProductCat");
  event.target.classList.add("currentProductCat");
};

const closeMenu = () => {
  document.querySelector(".sidebarMenu").style.opacity = "0";
  document.body.classList.remove("no-scroll");
  setTimeout(() => {
    document
      .querySelector(".sidebarMenu-container")
      .classList.add("menuClosed");
  }, 100);
};

const openMenu = () => {
  document
    .querySelector(".sidebarMenu-container")
    .classList.remove("menuClosed");
  document.body.classList.add("no-scroll");
  setTimeout(() => {
    document.querySelector(".sidebarMenu").style.opacity = "1";
  }, 200);
};

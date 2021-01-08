import { MOCK } from "./MOCK_DATA.js";

(function (data, document) {
    const keys = Object.keys(data[0]);

    function createTag(tag, content) {
        return `<${tag}>
    ${Array.isArray(content) ? content.join("") : content}
</${tag}>`;
    }

    function createSingleTag(tag, prop, val) {
        return `<${tag} ${prop}="${val}" />`;
    }

    const renderTable = createTag.bind(undefined, "table");
    const renderThead = createTag.bind(undefined, "thead");
    const renderTbody = createTag.bind(undefined, "tbody");
    const renderTr = createTag.bind(undefined, "tr");
    const renderTh = createTag.bind(undefined, "th");
    const renderTd = createTag.bind(undefined, "td");
    const renderUl = createTag.bind(undefined, "ul");
    const renderLi = createTag.bind(undefined, "li");

    function chooseContentType(map, defaultWrapper, type, content) {
        if (typeof map[type] === "function") {
            return defaultWrapper(map[type](type, content))
        }
        return defaultWrapper(content);
    }

    const fieldsMap = {
        avatar: (_, x) => createSingleTag("img", "src", x),
        friends: (_, list) => renderUl(
            list.map(f => renderLi(`${f.first_name} ${f.last_name}`))
        ),
        email: (_, x) => `<a href="mailto:${x}">${x}</a>`
    }

    const headingsMap = ["id", "first_name", "last_name", "email", "gender", "ip_address"]
        .reduce((a, b) => {
            a[b] = (type, content) => `<a class="filter" data-sortby="${type}">${content}</a>`
            return a;
        }, {});

    const defaultTd = chooseContentType.bind(
        undefined,
        fieldsMap, renderTd
    );

    const defaultTh = chooseContentType.bind(
        undefined,
        headingsMap, renderTh
    );

    const dict = {
        id: "Идент.",
        email: "Мейл",
        gender: "Пол",
        ip_address: "IP",
        first_name: "Име",
        avatar: "Картинка",
        friends: "Приятели",
        last_name: "Фамилия"
    }


    function main(data) {
        return renderTable(
            renderThead(
                renderTr(
                    keys.map(
                        key => defaultTh(key, dict[key])
                    )
                )
            )
            +
            renderTbody(
                data.map(
                    row => renderTr(
                        keys.map(
                            cell => defaultTd(cell, row[cell])
                        )
                    )
                )
            )
        )
    }

    function addToHTML(data) {
        document.getElementById("app").innerHTML = main(data);
    }

    addToHTML(data);


    function sortBy(key, a, b) {
        if (typeof a[key] === "number") {
            return a[key] - b[key];
        }
        return a[key].localeCompare(b[key]);
    }

    function clickHandler(data, evt) {
        if (evt.target.classList.contains("filter")) {
            addToHTML(
                data.sort(sortBy.bind(undefined, evt.target.dataset.sortby))
            );
        }
    }

    document.addEventListener("click", clickHandler.bind(undefined, data), true);

}(MOCK.slice(0, 20), document))

































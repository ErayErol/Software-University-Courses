const elements = {
    $getVenuesBtn: () => document.getElementById('getVenues'),
    $venueDataInput: () => document.getElementById('venueDate'),
    $venueInfo: () => document.getElementById('venue-info'),
    $venueDetailsDiv: () => document.getElementsByClassName('venue-details'),
    $confirmBtn: () => document.getElementById('confirm'),
};

elements.$getVenuesBtn().addEventListener('click', getVenues);

async function getVenues() {
    clearDiv();
    try {
        const headers = getHeader('POST');
        const responsePOST = await fetch(`https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/calendar?query=${elements.$venueDataInput().value}`, headers);
        const ids = await responsePOST.json();
        for (let id of ids) {
            const headers = getHeader('GET');
            const responseGET = await fetch(`https://baas.kinvey.com/appdata/kid_BJ_Ke8hZg/venues/${id}`, headers);
            const venue = await responseGET.json();
            displayVenues(venue);
        }
    } catch (error) {
        alert('Available dates are :\n23-11\n24-11\n25-11\n26-11\n27-11\nTry again, please...');
        clearInput();
    }

    function clearDiv() {
        elements.$venueInfo().innerHTML = '';
    }
    
    function clearInput() {
        elements.$venueDataInput().value = '';
    }
}

function displayVenues(venue) {
    let venueDiv = createVenueDiv();
    const moreInfoButton = venueDiv.getElementsByClassName('venue-name')[0];
    moreInfoButton.addEventListener('click', moreInfo);
    elements.$venueInfo().append(venueDiv);

    function moreInfo(event) {
        hideAllDescriptions();
        showCurrentDescription(event);
        const purchaseButton = venueDiv.getElementsByClassName('purchase')[0];
        purchaseButton.addEventListener('click', purchase);
    }

    function purchase() {
        const { name, qty, price, total, id } = getVenueDetails();
        confirmPurchase();
        finalPage();

        function finalPage() {
            elements.$confirmBtn().addEventListener('click', async () => {
                const headers = getHeader('POST');
                const responsePOST = await fetch(`https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${id}&qty=${qty}`, headers);
                const final = await responsePOST.json();
                elements.$venueInfo().innerHTML = `You may print this page as your ticket\n${final.html}`;
            });
        }

        function confirmPurchase() {
            elements.$venueInfo().innerHTML = `<span class="head">Confirm purchase</span>
            <div class="purchase-info">
            <span>${name}</span>
            <span>${qty} x ${price}</span>
            <span>Total: ${total} lv</span>
            <input type="button" value="Confirm" id="confirm">
            </div>`;
        }

        function getVenueDetails() {
            const id = venueDiv.id;
            const name = venueDiv.getElementsByClassName('venue-name')[0].textContent;
            const price = venueDiv.getElementsByClassName('venue-price')[0].textContent.split(' ')[0];
            const qty = venueDiv.getElementsByClassName('quantity')[0].value;
            const total = Number(qty) * Number(price);
            return { name, qty, price, total, id };
        }
    }

    function createVenueDiv() {
        let venueDiv = document.createElement('div');
        venueDiv.className = 'venue';
        venueDiv.id = venue._id;
        venueDiv.innerHTML = `<span class="venue-name">${venue.name} <input class="info" type="button" value="More info"></span>
                                <div class="venue-details" style="display: none;">
                                    <table>
                                        <tr>
                                            <th>Ticket Price</th>
                                            <th>Quantity</th>
                                            <th></th>
                                        </tr>
                                        <tr>
                                            <td class="venue-price">${venue.price} lv</td>
                                            <td><select class="quantity">
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            </select></td>
                                            <td><input class="purchase" type="button" value="Purchase"></td>
                                        </tr>
                                    </table>
                                    <span class="head">Venue description:</span>
                                        <p class="description">${venue.description}</p>
                                        <p class="description">Starting time: ${venue.startingHour}</p>
                                    </div>`;
        return venueDiv;
    }

    function showCurrentDescription(e) {
        e.currentTarget.parentNode.children[1].style.display = 'block';
    }

    function hideAllDescriptions() {
        [...elements.$venueDetailsDiv()].map(x => x.style.display = 'none');
    }
}

function getHeader(method) {
    return {
        method: method,
        headers: {
            'Authorization': `Basic Z3Vlc3Q6cGFzcw==`,
            'Content-Type': 'application/json',
        }
    };
}
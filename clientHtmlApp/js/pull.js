async function pullNameFilter()
{
    let orderItems = await getOrdersItems();

    let select = document.getElementById('filterByParam');
    for (let i = 0; i < orderItems.length; i++)
    {
        let option = document.createElement('option');
        option.innerHTML = orderItems[i].name;
        option.value = orderItems[i].name;
        select.appendChild(option);
    }
}

async function pullNumberFilter()
{
    let orders = await getOrders();

    let select = document.getElementById('filterByParam');
    for (let i = 0; i < orders.length; i++)
    {
        let option = document.createElement('option');
        option.innerHTML = orders[i].number;
        option.value = orders[i].number;
        select.appendChild(option);
    }
}

async function pullProviderFilter()
{
    let providers = await getProviders();
    let select = document.getElementById('filterByParam');
    for (let i = 0; i < providers.length; i++)
    {
        let option = document.createElement('option');
        option.innerHTML = providers[i].name;
        option.value = providers[i].name;
        select.appendChild(option);
    }
}

async function pullUnitFilter()
{
    let orderItems = await getOrdersItems();

    let select = document.getElementById('filterByParam');
    for (let i = 0; i < orderItems.length; i++)
    {
        let option = document.createElement('option');
        option.innerHTML = orderItems[i].unit;
        option.value = orderItems[i].unit;
        select.appendChild(option);
    }
}

async function pullOrders(list){
    
    if (list[0] === undefined) { return; }

    let table = document.getElementById('list-orders').getElementsByTagName('tbody')[0];

    for (let i = 0; i < list.length; i++)
    {
        let row = document.createElement('tr');
        let text = `<th>${list[i].id}</th>`;
        text += `<th>${list[i].number}</th>`;
        text += `<th>${list[i].date}</th>`;
        let provider = await getProviderById(list[i].providerId);
        text += `<th>${provider.name}</th>`;
        row.setAttribute('data-bs-target', '#showInfo');
        row.setAttribute('data-bs-toggle', 'modal');
        row.setAttribute('data-bs-target', '#showInfo');
        row.setAttribute('orderId', list[i].id);
        row.setAttribute('onclick', `showOrderInfo(${list[i].id})`);
        row.setAttribute('style', 'cursor: pointer;')
        row.innerHTML = text;
        table.appendChild(row);
    }
}

async function pullEditPage()
{
    await pullProviders();

    let s = window.location.search;
    s = s.match(new RegExp("id" + '=([^&=]+)'));
    let order = await getOrderById(s[1]);
    let provider = await getProviderById(order.providerId);
    let orderItem = await getOrderItemByOrderId(Number(s[1]));
    let select = document.getElementById('form-options');
    let date = order.date.split('T')[0].split('-');
    let dateFormat = date[0] + '-' + date[1] + '-' + date[2];
    document.getElementById('inputNumber').value = order.number;
    document.getElementById('inputDate').value = dateFormat;
    select.options[select.selectedIndex].text = provider.name;
    document.getElementById('inputName').value = orderItem.name;
    document.getElementById('inputQuantity').value = orderItem.quantity;
    document.getElementById('inputModel').value = orderItem.unit;

}


async function pullProviders(){
    let providers = await getProviders();
    let select = document.getElementById('form-options');
    for (let i = 0; i < providers.length; i++)
    {
        let option = document.createElement('option');
        option.innerHTML = providers[i].name;
        option.value = providers[i].id;
        select.appendChild(option);
    }
}
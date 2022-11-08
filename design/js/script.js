async function createOrder(){

    let providerId = await document.sform.inputProvider.selectedIndex;

    let response = await fetch("https://localhost:7252/api/Order/",
    {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            {
                number: document.sform.inputNumber.value,
                date: document.sform.inputDate.value,
                providerId: document.sform.inputProvider.options[providerId].value
            }
        )
    });

    let ordersList = await getOrders();
    let order = ordersList[ordersList.length-1];
    alert("Успешно!");
    
    await fetch("https://localhost:7252/api/OrderItem/",
    {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            {
                orderId: order.id,
                name: document.sform.inputName.value,
                quantity: document.sform.inputQuantity.value,
                unit: document.sform.inputModel.value
            }
        )
    });
}


async function deleteOrder(id)
{
    let response = await fetch(`https://localhost:7252/api/Order/${id}`, {
        method: "DELETE",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let order = await response.json();
        let table = document.getElementById('list-orders').getElementsByTagName('tbody')[0].innerHTML = "";
        await pullOrders();
        return order;
    }
    else{
        alert("error");
    }
}

async function deleteOrderItem(id)
{
    let response = await fetch(`https://localhost:7252/api/OrderItem/${id}`, {
        method: "DELETE",
        headers:  {"accept": "application/json"} 
    });

}

function goToEditPage(id)
{
    window.location.replace(`edit.html?id=${id}`);
}

async function pullOrders(){
    let orders = await getOrders();
    
    let table = document.getElementById('list-orders').getElementsByTagName('tbody')[0];
    for (let i = 0; i < orders.length; i++)
    {
        let row = document.createElement('tr');
        let text = `<th>${orders[i].id}</th>`;
        text += `<th>${orders[i].number}</th>`;
        text += `<th>${orders[i].date}</th>`;
        let provider = await getProviderById(orders[i].providerId);
        text += `<th>${provider.name}</th>`;
        row.setAttribute('data-bs-target', '#showInfo');
        row.setAttribute('data-bs-toggle', 'modal');
        row.setAttribute('data-bs-target', '#showInfo');
        row.setAttribute('orderId', orders[i].id);
        row.setAttribute('onclick', `showOrderInfo(${orders[i].id})`);
        row.setAttribute('style', 'cursor: pointer;')
        row.innerHTML = text;
        table.appendChild(row);
    }
}

async function pullEditPage()
{
    let s = window.location.search;
    s = s.match(new RegExp("id" + '=([^&=]+)'));
    let order = await getOrderById(s[1]);
    let provider = await getProviderById(order.providerId);
    let orderItem = await getOrderItemById(s[1]);
    document.getElementById('inputNumber').value = order.number;
    document.getElementById('inputDate').value = orderItem.date;
    document.getElementById('inputProvider').selectedIndex.value = provider.name;
    document.getElementById('inputName').value = orderItem.name;
    document.getElementById('inputQuantity').value = orderItem.Quantity;
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

async function getOrderItemById(id)
{
    let response = await fetch(`https://localhost:7252/api/OrderItem/${id}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let order = await response.json();
        
        return order;
    }
    else{
        alert("error");
    }
}

async function getOrderItemByOrderId(id)
{
    let response = await fetch(`https://localhost:7252/api/OrderItem`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let ordersItemList = await getOrdersItems();
        for (let i = 0; i < ordersItemList.length; i++)
        {
            if (ordersItemList[i].orderId === id)
            {
                return ordersItemList[i];
            }
        }
        return undefined;
    }
    else{
        alert("error");
    }
}

async function getOrdersItems(){
    let response = await fetch("https://localhost:7252/api/OrderItem", {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orders = await response.json();
        return orders;
    }
    else{
        alert("error");
    }
}

async function getProviderById(id){
    
    let response = await fetch(`https://localhost:7252/api/Provider/${id}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let provider = await response.json();
        return provider;
    }
    else{
        alert("error");
    }
}

async function getOrderById(id){
    
    let response = await fetch(`https://localhost:7252/api/Order/${id}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let order = await response.json();
        
        return order;
    }
    else{
        alert("error");
    }
}

async function getProviders(){
    
    let response = await fetch("https://localhost:7252/api/Provider", {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let providers = await response.json();
        return providers;
    }
    else{
        alert("error");
    }
}

async function getOrders(){
    let response = await fetch("https://localhost:7252/api/Order", {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orders = await response.json();
        return orders;
    }
    else{
        alert("error");
    }
}

async function showOrderInfo(id)
{
    let div = document.getElementById('modal-body-show');
    div.innerHTML = "";
    let newDiv = document.createElement('div');
    let order = await getOrderById(id);
    let orderItem = await getOrderItemByOrderId(order.id);
    console.log(orderItem);

    let text = `<p><b>Id</b>: ${order.id}</p>`;
    text += `<p><b>Имя</b>: ${orderItem.name}</p>`;
    text += `<p><b>Номер</b>: ${order.number}</p>`;
    text += `<p><b>Качество</b>: ${orderItem.quantity}</p>`;
    text += `<p><b>Материал</b>: ${orderItem.unit}</p>`;
    text += `<p><b>Дата</b>: ${order.date}</p>`;
    let provider = await getProviderById(order.providerId);
    text += `<p><b>Поставщик</b>: ${provider.name}</p>`;
    newDiv.innerHTML = text;
    div.appendChild(newDiv);

    let deleteButton = document.getElementById('delete-order');
    deleteButton.setAttribute('onclick', `deleteOrder(${id}); deleteOrderItem(${orderItem.id})`);

    let editButton = document.getElementById('edit-order');
    editButton.setAttribute('onclick', `goToEditPage(${id})`);
}

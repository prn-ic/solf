function goToEditPage(id)
{
    window.location.replace(`edit.html?id=${id}`);
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
        return 0;
    }
}

async function getOrderItemByOrderId(id)
{
    let response = await fetch(`https://localhost:7252/api/Order/${id}`, {
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


async function getOrderByProviderId(id)
{
    let response = await fetch(`https://localhost:7252/api/Order`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orders = await getOrders();
        for (let i = 0; i < orders.length; i++)
        {
            if (orders[i].providerId === id)
            {
                return orders[i];
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

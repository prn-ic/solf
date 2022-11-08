async function filterByName()
{
    let selectParam = document.getElementById('filterByParam');
    await isDefaultValue(selectParam.value);
    let response = await fetch(`https://localhost:7252/api/OrderItem/filterName/${selectParam.value}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orderItems = await response.json();
        let orders = [];
	for (let i = 0; i < orderItems.length; i++)
	{
	    orders.push(await getOrderById(orderItems[i].orderId));
	}
	
	await pullOrders(orders);
    }
    else{
        alert("error");
    }
}

async function filterByNumber()
{
    let selectParam = document.getElementById('filterByParam');
    await isDefaultValue(selectParam.value);
    let response = await fetch(`https://localhost:7252/api/Order/filterNumber/${selectParam.value}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orders = await response.json();
	await pullOrders(orders);
    }
    else{
        alert("error");
    }
}

async function filterByDate()
{
    let startDate = document.getElementById('startDateFilter').value;
    let endDate = document.getElementById('endDateFilter').value;
    let response = await fetch(`https://localhost:7252/api/Order/filterDate/${startDate}+${endDate}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orders = await response.json();
	await pullOrders(orders);
    }
    else{
        alert("error");
    }
}

async function filterByProvider()
{
    let selectParam = document.getElementById('filterByParam');
    await isDefaultValue(selectParam.value);
    let response = await fetch(`https://localhost:7252/api/Provider/filterName/${selectParam.value}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let providers = await response.json();
        let orders = [];
	for (let i = 0; i < providers.length; i++)
	{
	    orders.push(await getOrderByProviderId(providers[i].id));
	}
	
	await pullOrders(orders);
    }
    else{
        alert("error");
    }
}

async function filterByUnit()
{
    let selectParam = document.getElementById('filterByParam');
    await isDefaultValue(selectParam.value);
    let response = await fetch(`https://localhost:7252/api/OrderItem/filterUnit/${selectParam.value}`, {
        method: "GET",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let orderItems = await response.json();
        let orders = [];
	for (let i = 0; i < orderItems.length; i++)
	{
	    orders.push(await getOrderById(orderItems[i].orderId));
	}
	
	await pullOrders(orders);
    }
    else{
        alert("error");
    }
}

async function isDefaultValue(value)
{
    if (value === "default")
    {
        let orders = await getOrders();
        await pullOrders(orders);
        return;
    }
}

async function changeFilterParam()
{
    let select = document.getElementById('filterBy');
    let selectParam = document.getElementById('filterByParam');
    selectParam.innerHTML = "<option selected value='default'>Все</option>";
    let value = select.value;

    switch(value)
    {
        case "1":
            await pullNameFilter();
            break;
        case "2":
            await pullNumberFilter();
            break;
        case "4":
            await pullProviderFilter();
            break;
        case "5":
            await pullUnitFilter();
            break;
    }
}

async function filterButton()
{
    let table = document.getElementById('list-orders').getElementsByTagName('tbody')[0];
    table.innerHTML = "";

    let value = document.getElementById('filterBy').value;
    switch(value)
    {
        case "1":
	    await filterByName();
            break;
        case "2":
            await filterByNumber();
            break;
        case "3":
            await filterByDate();
            break;
	case "4":
	    await filterByProvider();
	    break;
	case "5":
	    await filterByUnit();
	    break;
    }
    
}
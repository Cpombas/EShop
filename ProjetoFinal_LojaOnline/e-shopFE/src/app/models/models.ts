export class Category {
    categoryId?: number;
    name : string = '';
    imageName: string ="";
}

export class Product {
    productId?: number;
    name: string = '';
    price: number | undefined;
    brand: string = '';
    description: string = '';
    categoryId?: number;
    imageName: string = ''; 
}

export class User {
    userId?: number;
    userName: string = '';
    password: string = ''
    firstName: string = '';
    lastName: string = '';
    age: number | undefined;
    email: string = '';
    address: string = '';
    role: string = '';  
}

export class Order {
    orderId?: number;
    userId: number | undefined;
    dateOfOrder: Date | undefined;
    dateOfDelivery: Date | undefined;
    totalPrice: number | undefined;
    orderStatus: string = '';
}

export class OrderProduct {
    orderProductId?: number;
    orderId: number | undefined;
    productId: number | undefined;
    quantity: number | undefined;
    price: number | undefined;
}
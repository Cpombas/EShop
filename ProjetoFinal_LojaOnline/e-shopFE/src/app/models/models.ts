export class Category {
    categoryId: number = 0;
    name : string = '';
    imageName: string ="";
}

export class Product {
    productId: number =0;
    name: string = '';
    price: number = 0;
    brand: string = '';
    description: string = '';
    categoryId?: number;
    imageName: string = ''; 
}

export class User {
    userId: number = 0;
    userName: string = '';
    password: string = ''
    firstName: string = '';
    lastName: string = '';
    age: number = 0;
    email: string = '';
    address: string = '';
    role: string = '';  
}

export class Order {
    orderId: number = 0;
    userId: number = 0;
    dateOfOrder: Date | undefined;
    dateOfDelivery: Date | undefined;
    totalPrice: number = 0;
    orderStatus: string = '';
}

export class OrderProduct {
    orderProductId: number = 0;
    orderId: number = 0;
    productId: number = 0;
    quantity: number = 0;
    price: number = 0;
}

export class Payment{
    paymentId: number=0;
    cardOwnerName: string='';
    cardNumber: string='';
    securityCode: string='';
    expirationDate: string='';
}
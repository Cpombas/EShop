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
    UserName: string = '';
    password: string = ''
    firstName: string = '';
    lastName: string = '';
    age: number | undefined;
    email: string = '';
    address: string = '';
    roleId: string = '';  
}
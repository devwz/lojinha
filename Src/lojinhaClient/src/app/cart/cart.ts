export interface CartItem {
    id: number;
    imgUrl: string;
    price: number;
    title: string;
    unit: number;
}

export interface Cart {
    id: number;
    cartKey: string;
    cartItem: CartItem[];
}
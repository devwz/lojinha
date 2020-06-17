export interface CartItem {
    unid: number;
    id: number;
}

export interface Cart {
    cartKey: string;
    cartItem: CartItem[];
    id: number;
}
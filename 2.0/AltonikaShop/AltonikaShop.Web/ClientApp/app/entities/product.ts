import { NamedEntity } from 'nglib';
import { BasketItem } from './basket-item';

export class Product extends NamedEntity {
    
    code: string;
    price: number;
    description: string;
    imageSource: string;
    isDeleted: boolean;
    isFavorite: boolean;
    
    constructor() {
        super();
    }
}

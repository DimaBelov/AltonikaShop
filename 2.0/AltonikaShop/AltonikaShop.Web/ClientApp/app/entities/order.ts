import { OrderDetail } from './order-detail';

export class Order {
    id: number;
    details: Array<OrderDetail>;
    createDate: Date;
}

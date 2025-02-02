import { User } from "./User";

export interface Review {
    id: number;
    body: string;
    rating: number;
    campgroundId: number;
    user: User;
    userId: number;

    author: string;
}
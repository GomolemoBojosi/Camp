import { Campground } from "./campground";

export interface Review {
    id: number;
    body: string;
    rating: number;
    campground: Campground;
    campgroundId: number;
}
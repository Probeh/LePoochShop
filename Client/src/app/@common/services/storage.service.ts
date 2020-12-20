import { Subject     } from 'rxjs'
import { Injectable  } from '@angular/core'
import { AppSettings } from '@helpers/app.settings'
import { IKeyValue   } from '@helpers/key.value'
import { ModelBase   } from '@models/base.model'

@Injectable()
export class StorageService {
  private readonly collection: IKeyValue<any> = {};
  private readonly collection$: IKeyValue<Subject<any>> = {};

  // ======================================= //
  constructor(private config: AppSettings) { }
  // ======================================= //
  public getStorage<T extends ModelBase<T>>(key: string): Promise<T[]> {
    return Promise.resolve().then<T[]>(async () => {

      const values: IKeyValue<T> = JSON.parse(localStorage.getItem(key));
      this.collection[key] = values
        ? Object.keys(values)
          .map(item => item[key])
        : new Array<T>();

      return this.collection[key].slice() as T[];
    });
  }
  public updateStorage<T extends ModelBase<T>>(key: string, values: T[]): Promise<T[]> {
    return Promise.resolve().then<T[]>(async () => {

      const storage: T[] = await this.getStorage(key);
      values.forEach(current => {
        const index = storage.findIndex(item => item?.id == current?.id || item?.name == current.name);
        index > -1 ? storage.splice(index, 1, current) : storage.push(current);
      });
      this.getCollection$(key)
        .next(await this.setStorage(key, storage.filter(value => value)));

      return storage.filter(value => value) as T[];
    });
  }
  public getCollection$<T extends ModelBase<T>>(key: string): Subject<T[]> {
    if (!this.collection$[key])
      this.collection$[key] = new Subject<T[]>();

    return this.collection$[key] as Subject<T[]>;
  }
  private setStorage<T extends ModelBase<T>>(key: string, values?: T[]): Promise<T[]> {
    return Promise.resolve().then<T[]>(async () => {

      const storage: IKeyValue<T> = {};
      values.forEach(item => storage[item.name] = item);
      localStorage.setItem(key, JSON.stringify(storage));

      return await this.getStorage<T>(key) as T[];
    });
  }
}
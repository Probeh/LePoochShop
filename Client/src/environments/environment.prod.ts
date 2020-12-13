import { Provider } from '@enums/providers.enum';
import { Endpoints } from '@helpers/endpoint.interface';

const endpoints: Endpoints = {
  [Provider.Server]: {

  }
}

export const environment = {
  production: true,
  endpoints: endpoints
};

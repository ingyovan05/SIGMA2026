export interface LoginRequest {
  userName: string;
  password: string;
}

export interface UserPermission {
  functionCode: number;
  granted: boolean;
}

export interface UserSession {
  personId: number;
  fullName: string;
  identification: string;
  userTypeCode: number;
  warehouse: { id: number; abbreviation: string | null; name: string | null } | null;
  sisControl: {
    dependencyId: number;
    baseAbbreviation: string | null;
    dependencyName: string | null;
  } | null;
  permissions: UserPermission[];
}

export interface LoginResponse {
  accessToken: string;
  expiresAt: string;
  user: UserSession;
}

export interface SystemModule {
  key: string;
  name: string;
  status: 'available' | 'planned';
}

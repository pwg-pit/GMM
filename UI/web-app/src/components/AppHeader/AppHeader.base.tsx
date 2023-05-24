// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.import React from "react";

import { classNamesFunction, IProcessedStyleSet } from '@fluentui/react';
import { useTheme } from '@fluentui/react/lib/Theme';
import { useTranslation } from 'react-i18next';
import WelcomeName from '../WelcomeName';
import {
  AccountManagementIcon,
  SettingsIcon,
} from '@fluentui/react-icons-mdl2';
import {
  type IAppHeaderProps,
  type IAppHeaderStyleProps,
  type IAppHeaderStyles,
} from './AppHeader.types';

const getClassNames = classNamesFunction<
  IAppHeaderStyleProps,
  IAppHeaderStyles
>();

export const AppHeaderBase: React.FunctionComponent<IAppHeaderProps> = (
  props: IAppHeaderProps
) => {
  const { className, styles } = props;
  const { t } = useTranslation();
  const classNames: IProcessedStyleSet<IAppHeaderStyles> = getClassNames(
    styles,
    {
      className,
      theme: useTheme(),
    }
  );

  return (
    <header>
      <div className={classNames.whole}>
        <div className={classNames.root} role="banner" aria-label="header">
          <div className={classNames.tabContent}>
            {' '}
            <div className={classNames.circle}>
              <div className={classNames.icon}>
                <AccountManagementIcon />
              </div>{' '}
            </div>{' '}
          </div>
          <div className={classNames.tabContent}> {t('membershipManagement')} </div>
          <div className={classNames.right}>
            <SettingsIcon />
          </div>
        </div>
        <br />
        <div className={classNames.welcome} role="banner" aria-label="header">
          <WelcomeName />
        </div>
        <div className={classNames.learn} role="banner" aria-label="header">
          <br /> {t('learnMembershipManagement')}
          <br />
        </div>
        <br />
      </div>
    </header>
  );
};

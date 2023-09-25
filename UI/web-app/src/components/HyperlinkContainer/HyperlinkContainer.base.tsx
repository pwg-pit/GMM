// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

import { classNamesFunction, type IProcessedStyleSet } from '@fluentui/react';
import { useTranslation } from 'react-i18next';
import { useTheme } from '@fluentui/react/lib/Theme';
import React, { useState } from 'react';
import { TextField } from '@fluentui/react/lib/TextField';

import {
    type IHyperlinkContainerProps,
    type IHyperlinkContainerStyleProps,
    type IHyperlinkContainerStyles,
} from './HyperlinkContainer.types';

export const getClassNames = classNamesFunction<IHyperlinkContainerStyleProps, IHyperlinkContainerStyles>();

export const HyperlinkContainerBase: React.FunctionComponent<IHyperlinkContainerProps> = (
    props: IHyperlinkContainerProps
) => {
    const { title, description, link, onUpdateLink, setHyperlinkError, className, styles } = props;
    const classNames: IProcessedStyleSet<IHyperlinkContainerStyles> = getClassNames(styles, {
        className,
        theme: useTheme(),
    });
    const { t } = useTranslation();
    const handleLinkChange = (newValue: string) => {
        onUpdateLink(newValue); 
    };

    const getErrorMessage = (value: string): string => {
        const isValid = isValidURL(value);
        setHyperlinkError(!isValid);
        return isValid ? '' : t('AdminConfig.hyperlinkContainer.invalidUrl') as string;
    };

    const isValidURL = (url: string): boolean => {
        try {
            new URL(url);
            return true;
        } catch (error) {
            return false;
        }
    }

    return (
        <div className={classNames.card}>
            <div className={classNames.title}>
                {title}
            </div>
            <div className={classNames.description}>
                {description}
            </div>
            <div>
                <TextField
                    label={t('AdminConfig.hyperlinkContainer.address') as string}
                    placeholder={t('AdminConfig.hyperlinkContainer.addHyperlink') as string}
                    value={link}
                    onChange={(e, newValue) => handleLinkChange(newValue ?? '')}
                    styles={{
                        fieldGroup: classNames.textFieldFieldGroup,
                    }}
                    onGetErrorMessage={getErrorMessage}
                ></TextField>
            </div>
        </div>
    )
};
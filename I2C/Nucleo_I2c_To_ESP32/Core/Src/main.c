/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2021 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <string.h>
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */
uint8_t crc_calc(uint8_t *data, unsigned int length);
/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
I2C_HandleTypeDef hi2c1;

UART_HandleTypeDef huart2;

/* USER CODE BEGIN PV */
static const uint8_t ESP_ADDR = 0x04 << 1; // Shift address to left to make space for W/R bit
uint8_t transmitBuffer[15];
uint8_t emptyPacket [4];
uint8_t receiveBuffer[17];
uint8_t statusBuffer[28];
uint8_t seed = 0;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_USART2_UART_Init(void);
static void MX_I2C1_Init(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

	HAL_StatusTypeDef ret;

	/* The ESP32 code for I2C implements a WirePacker library which packs and unpacks data for transmission
	 * purposes. To communicate with the ESP32 the nucleo-f303re needs to start transmission with 0x02,
	 * add the number of payload bytes (which is noted as n) with 4, add the preferred amount of data up to
	 * 124 bytes (128 bytes in total of which 4 are used by start, length, crc and end), add CRC and end
	 * the transmission with 0x04.
	 *
	 * _____________________________________________________________________________________________________
	 * |            | Start | Length  | Data [0] | Data[1] | ... | Data[n-1] |       CRC8        |   End   |
	 * -----------------------------------------------------------------------------------------------------
	 * | byte index |   0   |    1    |     2    |    3    | ... |    n+1    |        n+2        |   n+3   |
	 * -----------------------------------------------------------------------------------------------------
	 * |   value    | 0x02  |   n+4   |  data[0] | data[1] | ... | data[n-1] | crc of [1..(n+1)] |   0x04  |
	 * -----------------------------------------------------------------------------------------------------
	 *
	 * The nucleo-f303re has to send an empty packet first in order to receive data from the ESP32.
	 *
	 * NOTE: most values are hard coded for testing purposes. Add your own code to automatically fill
	 * the buffers
	*/

	transmitBuffer[0] = 0x02;
	transmitBuffer[1] = sizeof(transmitBuffer) / sizeof(transmitBuffer[0]);
	transmitBuffer[2] = 'F';
	transmitBuffer[3] = 'r';
	transmitBuffer[4] = 'o';
	transmitBuffer[5] = 'm';
	transmitBuffer[6] = ' ';
	transmitBuffer[7] = 'N';
	transmitBuffer[8] = 'u';
	transmitBuffer[9] = 'c';
	transmitBuffer[10] = 'l';
	transmitBuffer[11] = 'e';
	transmitBuffer[12] = 'o';
	transmitBuffer[13] = crc_calc(transmitBuffer + 2, 11);
	transmitBuffer[14] = 0x04;

	emptyPacket[0] = 0x02;
	emptyPacket[1] = 4;
	emptyPacket[2] = crc_calc(emptyPacket + 2, 1);
	emptyPacket[3] = 0x04;

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART2_UART_Init();
  MX_I2C1_Init();
  /* USER CODE BEGIN 2 */

  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
	  // First transmit an empty packet and receive data from ESP32
	  seed = 0;
	  ret = HAL_I2C_Master_Transmit(&hi2c1, ESP_ADDR, emptyPacket, (sizeof(emptyPacket) / sizeof(emptyPacket[0])), HAL_MAX_DELAY); // Transmitting empty packet over I2C

	  // Use the return value to decide follow up steps and transmit this value over UART
	  if (ret != HAL_OK)
	  {
		  strcpy((char*)statusBuffer, "Error while transmitting\r\n");
		  HAL_UART_Transmit(&huart2, statusBuffer, strlen((char*)statusBuffer), HAL_MAX_DELAY);
	  }
	  else
	  {
		  strcpy((char*)statusBuffer, "Successfully transmitted\r\n");
		  HAL_UART_Transmit(&huart2, statusBuffer, strlen((char*)statusBuffer), HAL_MAX_DELAY);

		  ret = HAL_I2C_Master_Receive(&hi2c1, ESP_ADDR, receiveBuffer, (sizeof(receiveBuffer) / sizeof(receiveBuffer[0])), HAL_MAX_DELAY); // Receiving data from ESP32
		  if (ret != HAL_OK)
		  {
			  strcpy((char*)statusBuffer, "Problem during receiving\r\n");
			  HAL_UART_Transmit(&huart2, statusBuffer, strlen((char*)statusBuffer), HAL_MAX_DELAY);
		  }
		  else
		  {
			  // Transmit the received data over UART
			  HAL_UART_Transmit(&huart2, &receiveBuffer[2], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[3], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[4], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[5], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[6], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[7], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[8], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[9], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[10], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[11], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[12], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[13], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[14], 1, HAL_MAX_DELAY);

			  receiveBuffer[15] = '\r';
			  receiveBuffer[16] = '\n';
			  HAL_UART_Transmit(&huart2, &receiveBuffer[15], 1, HAL_MAX_DELAY);
			  HAL_UART_Transmit(&huart2, &receiveBuffer[16], 1, HAL_MAX_DELAY);
		  }
	  }

	  HAL_Delay(1000);

	  ret = HAL_I2C_Master_Transmit(&hi2c1, ESP_ADDR, transmitBuffer, (sizeof(transmitBuffer) / sizeof(transmitBuffer[0])), HAL_MAX_DELAY); // Transmitting empty packet over I2C

	  // Use the return value to decide follow up steps and transmit this value over UART
	  if (ret != HAL_OK)
	  {
		  strcpy((char*)statusBuffer, "Error while transmitting\r\n");
		  HAL_UART_Transmit(&huart2, statusBuffer, strlen((char*)statusBuffer), HAL_MAX_DELAY);
	  }
	  else
	  {
		  strcpy((char*)statusBuffer, "Successfully transmitted\r\n");
		  HAL_UART_Transmit(&huart2, statusBuffer, strlen((char*)statusBuffer), HAL_MAX_DELAY);
	  }

	  HAL_Delay(1000);

    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */

  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL9;
  RCC_OscInitStruct.PLL.PREDIV = RCC_PREDIV_DIV1;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_USART2|RCC_PERIPHCLK_I2C1;
  PeriphClkInit.Usart2ClockSelection = RCC_USART2CLKSOURCE_PCLK1;
  PeriphClkInit.I2c1ClockSelection = RCC_I2C1CLKSOURCE_HSI;
  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief I2C1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_I2C1_Init(void)
{

  /* USER CODE BEGIN I2C1_Init 0 */

  /* USER CODE END I2C1_Init 0 */

  /* USER CODE BEGIN I2C1_Init 1 */

  /* USER CODE END I2C1_Init 1 */
  hi2c1.Instance = I2C1;
  hi2c1.Init.Timing = 0x2000090E;
  hi2c1.Init.OwnAddress1 = 0;
  hi2c1.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
  hi2c1.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
  hi2c1.Init.OwnAddress2 = 0;
  hi2c1.Init.OwnAddress2Masks = I2C_OA2_NOMASK;
  hi2c1.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
  hi2c1.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
  if (HAL_I2C_Init(&hi2c1) != HAL_OK)
  {
    Error_Handler();
  }
  /** Configure Analogue filter
  */
  if (HAL_I2CEx_ConfigAnalogFilter(&hi2c1, I2C_ANALOGFILTER_ENABLE) != HAL_OK)
  {
    Error_Handler();
  }
  /** Configure Digital filter
  */
  if (HAL_I2CEx_ConfigDigitalFilter(&hi2c1, 0) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN I2C1_Init 2 */

  /* USER CODE END I2C1_Init 2 */

}

/**
  * @brief USART2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART2_UART_Init(void)
{

  /* USER CODE BEGIN USART2_Init 0 */

  /* USER CODE END USART2_Init 0 */

  /* USER CODE BEGIN USART2_Init 1 */

  /* USER CODE END USART2_Init 1 */
  huart2.Instance = USART2;
  huart2.Init.BaudRate = 9600;
  huart2.Init.WordLength = UART_WORDLENGTH_8B;
  huart2.Init.StopBits = UART_STOPBITS_1;
  huart2.Init.Parity = UART_PARITY_NONE;
  huart2.Init.Mode = UART_MODE_TX_RX;
  huart2.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart2.Init.OverSampling = UART_OVERSAMPLING_16;
  huart2.Init.OneBitSampling = UART_ONE_BIT_SAMPLE_DISABLE;
  huart2.AdvancedInit.AdvFeatureInit = UART_ADVFEATURE_NO_INIT;
  if (HAL_UART_Init(&huart2) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART2_Init 2 */

  /* USER CODE END USART2_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOC_CLK_ENABLE();
  __HAL_RCC_GPIOF_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(LD2_GPIO_Port, LD2_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pin : B1_Pin */
  GPIO_InitStruct.Pin = B1_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_FALLING;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  HAL_GPIO_Init(B1_GPIO_Port, &GPIO_InitStruct);

  /*Configure GPIO pin : LD2_Pin */
  GPIO_InitStruct.Pin = LD2_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(LD2_GPIO_Port, &GPIO_InitStruct);

}

/* USER CODE BEGIN 4 */
uint8_t crc_calc(uint8_t *data, unsigned int length)
{
    uint8_t crc = seed;
    uint8_t extract;
    uint8_t sum;

    for (unsigned int i = 0; i < length; i++) {
        extract = *data;

        for (char j = 8; j; j--) {
            sum = (crc ^ extract) & 0x01;
            crc >>= 1;
            if (sum) {
                crc ^= 0x8C;
            }
            extract >>= 1;
        }

        data++;
    }

    return crc;
}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */

  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     tex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

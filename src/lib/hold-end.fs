\ lib/hold-end.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230430T0946+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require constant.fs    \ `constant`
require hold-buffer.fs \ `hold-buffer`

compiler{ hold-buffer_dea /hold-buffer host{ + } } constant hold-end ( -- ca )

  \ doc{
  \
  \ hold-end ( -- ca )
  \
  \ _ca_ is the address right above `hold-buffer`, used by `<#` to
  \ init `hld`.
  \
  \ See also: `/hold-buffer`.
  \
  \ }doc

\ lib/pad.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230430T0730+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require buffer-colon.fs \ `buffer:`

compiler{ /pad } buffer: pad ( -- ca )

  \ doc{
  \
  \ pad ( -- ca )
  \
  \ _ca_ is the address of a region that can be used to hold data for
  \ intermediate processing. Its size is `/pad`.
  \
  \ ``pad`` is  specifically intended as  a programmer convenience. No
  \ other words use it.
  \
  \ }doc

\ lib/create.fs

\ This file is part of Sin Forth.

\ This file adds `create` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: create ( "name" -- )
  creator ,
  does> ( dfa ) @ h ldp#, push-hl ;

  \ doc{
  \
  \ create ( "name" -- )

  \ Parse _name_.  Create  a definition for _name_.  After _name_
  \ is created, the data-space pointer (returned by `here`),
  \ points to the first byte of __name__'s data field.  When
  \ _name_ is subsequently executed, the address of the first byte
  \ of __name__'s data field is left on the stack.
  \
  \ ``create`` does not allocate data space in __name__'s data
  \ field. Reservation of data field space is tipically done with
  \ `allot`.
  \
  \ // XXX TODO
  \ // The execution semantics of _name_ may be expanded by using
  \ // `does>`.
  \
  \ See also: `variable` `,`, `c,`, `2,`.
  \
  \ }doc

set-current set-order
